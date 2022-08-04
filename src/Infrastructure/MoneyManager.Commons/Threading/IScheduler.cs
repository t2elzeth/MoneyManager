using System;

namespace MoneyManager.Commons.Threading;

public interface IScheduler
{
    bool Ready(DateTime dateTime);
}

public class NoScheduler : IScheduler
{
    public static readonly IScheduler Instance = new NoScheduler();

    public bool Ready(DateTime dateTime) => true;
}