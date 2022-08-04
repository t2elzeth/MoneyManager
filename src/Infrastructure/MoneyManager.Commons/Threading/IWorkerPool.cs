using System;
using System.Collections.Concurrent;
using System.Threading;

namespace MoneyManager.Commons.Threading;

public interface IWorkerPool
{
    IAgent Start(IWorker worker, IScheduler? scheduler = null, object? context = null);

    void Stop(IWorker worker, int timeout);

    void StopPool(int timeout);

    void WaitAll();
}

public class WorkerPool : IWorkerPool
{
    private bool _poolStarted;
    private readonly object _syncObject = new();
    private int _workersCount;

    private readonly IAgentFactory _agentFactory = new AgentFactory();
    private readonly ConcurrentDictionary<IWorker, IAgent> _agents = new();

    public WorkerPool()
    {
        _poolStarted = true;
    }

    public IAgent Start(IWorker worker, IScheduler? scheduler = null, object? context = null)
    {
        scheduler ??= NoScheduler.Instance;

        lock (_syncObject)
        {
            if (!_poolStarted)
                throw new Exception("Pool is stopped");

            if (_agents.ContainsKey(worker))
                throw new Exception("Worker is already started");

            var agent = _agentFactory.Create(worker, scheduler);

            _agents[worker]      =  agent;
            agent.WorkerFinished += WorkerFinished;
            agent.Start(context);

            Interlocked.Increment(ref _workersCount);

            return agent;
        }
    }

    private void WorkerFinished(object sender, WorkerFinishedEventArgs e)
    {
        if (_agents.TryRemove(e.Worker, out _))
            Interlocked.Decrement(ref _workersCount);
    }

    public void Stop(IWorker worker, int timeout)
    {
        if (worker == null)
            throw new ArgumentNullException(nameof(worker));

        lock (_syncObject)
        {
            if (!_poolStarted)
                throw new Exception("Pool is stopped");

            if (!_agents.TryRemove(worker, out var agent))
                throw new Exception("Worker thread is not found");

            agent.Stop(timeout);
        }
    }

    public void StopPool(int timeout)
    {
        lock (_syncObject)
        {
            if (!_poolStarted)
                throw new Exception("Pool is stopped");

            _poolStarted = false;

            foreach (var agent in _agents.Values)
            {
                agent.Stop(timeout);
            }

            _agents.Clear();
        }
    }

    public void WaitAll()
    {
        while (_workersCount > 0)
        {
            Thread.Sleep(1);
        }
    }
}