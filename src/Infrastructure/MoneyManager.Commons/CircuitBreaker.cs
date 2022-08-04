using System;

namespace MoneyManager.Commons;

public enum CircuitBreakerState
{
    Closed,
    Open,
    HalfOpen
}

public class CircuitBreakerOpenException : Exception { }

public class CircuitBreaker
{
    private readonly object _syncObject = new object();

    public CircuitBreakerState State { get; private set; } = CircuitBreakerState.Closed;

    private DateTime _lastExceptionTimestamp;

    public TimeSpan OpenInterval { get; set; }

    public CircuitBreaker()
    {
        OpenInterval = TimeSpan.FromSeconds(30);
    }

    public CircuitBreaker(TimeSpan openInterval)
    {
        OpenInterval = openInterval;
    }

    public void Execute(Action action)
    {
        if (State == CircuitBreakerState.Open)
        {
            if (_lastExceptionTimestamp + OpenInterval >= DateTime.Now)
                throw new CircuitBreakerOpenException();

            try
            {
                lock (_syncObject)
                {
                    State = CircuitBreakerState.HalfOpen;
                    action();
                    State = CircuitBreakerState.Closed;
                    return;
                }
            }
            catch
            {
                OpenCircuit();
                throw;
            }
        }

        try
        {
            action();
        }
        catch
        {
            OpenCircuit();
            throw;
        }
    }

    public TResult Execute<TResult>(Func<TResult> func)
    {
        if (State == CircuitBreakerState.Open)
        {
            if (_lastExceptionTimestamp + OpenInterval >= DateTime.Now)
                throw new CircuitBreakerOpenException();

            try
            {
                lock (_syncObject)
                {
                    State = CircuitBreakerState.HalfOpen;
                    var result = func();
                    State = CircuitBreakerState.Closed;
                    return result;
                }
            }
            catch
            {
                OpenCircuit();
                throw;
            }
        }

        try
        {
            return func();
        }
        catch
        {
            OpenCircuit();
            throw;
        }
    }

    private void OpenCircuit()
    {
        State                   = CircuitBreakerState.Open;
        _lastExceptionTimestamp = DateTime.Now;
    }
}