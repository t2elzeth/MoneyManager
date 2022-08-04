using System;
using System.Threading;
using Commons.Logging;

namespace MoneyManager.Commons.Threading;

public class WorkerFinishedEventArgs : EventArgs
{
    public IWorker Worker { get; private set; }

    public WorkerFinishedEventArgs(IWorker worker)
    {
        Worker = worker;
    }
}

public interface IAgent
{
    void Start(object? context);

    void Stop(int timeout);

    void Pause();

    void Resume();

    event EventHandler<WorkerFinishedEventArgs> WorkerFinished;
}

internal class Agent : IAgent
{
    public static readonly ILogger Logger = LoggerFactory.Create<Agent>();

    private Thread _thread;

    private volatile bool _stop;

    private volatile bool _pause;

    private readonly IWorker _worker;
    private readonly IScheduler _scheduler;

    public event EventHandler<WorkerFinishedEventArgs> WorkerFinished;

    protected virtual void RaiseWorkerFinished(IWorker worker)
    {
        WorkerFinished?.Invoke(this, new WorkerFinishedEventArgs(worker));
    }

    public Agent(IWorker worker, IScheduler scheduler)
    {
        _worker    = worker;
        _scheduler = scheduler;
    }

    public void Stop(int timeout)
    {
        _stop = true;

        Logger.Info($"Stopping worker '{_worker.Name}'");

        _thread.Join(timeout);

        if (_thread.IsAlive)
        {
            Logger.Info($"Aborting worker '{_worker.Name}'");

            _thread.Abort();
        }

        {
            Logger.Info($"Worker '{_worker.Name}' is stopped");
        }
    }

    public void Pause() => _pause = true;

    public void Resume() => _pause = false;

    public void Start(object? context)
    {
        _worker.Context = context;

        if (_thread != null && _thread.IsAlive)
            throw new InvalidOperationException("Agent is already started");

        _stop = false;

        _thread = new Thread(Run)
        {
            Name = _worker.Name
        };

        _worker.Starting();

        _thread.Start();
    }

    private void Run()
    {
        Logger.Debug($"Starting worker '{_worker.Name}'");

        try
        {
            if (DoWork(_worker.Started) == WorkerState.Finished)
                return;
        }
        catch (Exception ex)
        {
            Logger.Error(ex, $"Cannot start worker '{_worker.Name}'");
            return;
        }

        Logger.Debug($"Worker '{_worker.Name}' is started");

        try
        {
            while (!_stop)
            {
                Thread.Sleep(1);

                if (_pause)
                    continue;

                if (!_scheduler.Ready(DateTime.Now))
                    continue;

                try
                {
                    if (DoWork(_worker.Work) == WorkerState.Finished)
                        return;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, $"Worker '{_worker.Name}' returned an exception");

                    try
                    {
                        if (DoWork(() => _worker.Fallback(ex)) == WorkerState.Finished)
                            return;
                    }
                    catch (Exception fallbackException)
                    {
                        Logger.Error(fallbackException, $"Worker '{_worker.Name}' returned an exception during fallback");
                    }
                }
            }
        }
        catch (ThreadAbortException)
        {
        }
        finally
        {
            try
            {
                _worker.Stopped();
            }
            catch (ThreadAbortException)
            {
                Logger.Debug($"Worker '{_worker.Name}' is aborted");
            }
            catch (Exception ex)
            {
                Logger.Debug(ex, $"Cannot stop worker '{_worker.Name}'");
            }
        }
    }

    private WorkerState DoWork(Func<WorkerState> action)
    {
        if (action() == WorkerState.Running)
            return WorkerState.Running;

        Logger.Debug($"Worker '{_worker.Name}' is finished");

        try
        {
            RaiseWorkerFinished(_worker);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "An error has occured during worker finished event");
        }

        return WorkerState.Finished;
    }
}