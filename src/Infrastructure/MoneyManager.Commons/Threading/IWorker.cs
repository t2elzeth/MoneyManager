using System;

namespace MoneyManager.Commons.Threading;

public enum WorkerState
{
    Running,
    Finished
}

public interface IWorker
{
    object? Context { get; set; }

    string Name { get; }

    void Starting();

    WorkerState Started();

    WorkerState Work();

    void Stopped();

    WorkerState Fallback(Exception ex);
}

public abstract class Worker : IWorker
{
    public object? Context { get; set; }

    public abstract string Name { get; }

    public virtual void Starting() { }
        
    public virtual WorkerState Started()
    {
        return WorkerState.Running;
    }

    public abstract WorkerState Work();

    public virtual void Stopped() { }

    public virtual WorkerState Fallback(Exception ex)
    {
        return WorkerState.Running;
    }
}