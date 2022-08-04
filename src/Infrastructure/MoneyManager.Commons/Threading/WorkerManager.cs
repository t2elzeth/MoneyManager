using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Commons.Threading;

public static class WorkerManager
{
    public const string DefaultPoolName = "Default Worker Pool";

    private static readonly ConcurrentDictionary<string, IWorkerPool> WorkerPools = new();

    private static IWorkerPoolFactory _workerPoolFactory = new DefaultWorkerPoolFactory();

    public static IAgent Start(IWorker worker,
                               IScheduler? scheduler = null,
                               object? state = null,
                               string poolName = DefaultPoolName)
    {
        var workerPool = WorkerPools.GetOrAdd(poolName, _workerPoolFactory.Create());

        return workerPool.Start(worker, scheduler, state);
    }

    public static void Stop(IWorker worker, int timeout, string poolName = DefaultPoolName)
    {
        if (!WorkerPools.TryGetValue(poolName, out IWorkerPool workerPool))
            throw new InvalidOperationException($"Pool '{poolName}' is not found");

        workerPool.Stop(worker, timeout);
    }

    public static IWorkerPool? GetPool(string poolName)
    {
        return WorkerPools.TryGetValue(poolName, out IWorkerPool workerPool) ? workerPool : null;
    }

    public static void StopPool(string poolName, int timeout)
    {
        if (!WorkerPools.TryRemove(poolName, out IWorkerPool workerPool))
            throw new InvalidOperationException($"Pool '{poolName}' is not found");

        workerPool.StopPool(timeout);
    }

    public static void StopAll(int timeout)
    {
        var poolNames = new string[WorkerPools.Keys.Count];
        WorkerPools.Keys.CopyTo(poolNames, 0);

        foreach (var poolName in poolNames)
        {
            StopPool(poolName, timeout);
        }
    }

    public static IList<string> GetPoolNames()
    {
        return WorkerPools.Keys.ToList();
    }

    public static void WaitAll()
    {
        foreach (var workerPool in WorkerPools.Values)
        {
            workerPool.WaitAll();
        }
    }
}