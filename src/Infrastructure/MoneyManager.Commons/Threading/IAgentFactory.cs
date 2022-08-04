using System;

namespace MoneyManager.Commons.Threading;

public interface IAgentFactory
{
    IAgent Create(IWorker worker, IScheduler scheduler);
}

public class AgentFactory : IAgentFactory
{
    public IAgent Create(IWorker worker, IScheduler scheduler)
    {
        if (worker == null)
            throw new ArgumentNullException(nameof(worker));

        if (scheduler == null)
            throw new ArgumentNullException(nameof(scheduler));

        return new Agent(worker, scheduler);
    }
}