namespace MoneyManager.Commons.Threading;

public interface IWorkerPoolFactory
{
    IWorkerPool Create();
}

public class DefaultWorkerPoolFactory : IWorkerPoolFactory
{
    public IWorkerPool Create()
    {
        return new WorkerPool();
    }
}