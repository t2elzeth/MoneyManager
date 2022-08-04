using System;
using System.Threading;

namespace Infrastructure.Nh.Postgres.Contexts;

public class AsyncNhSessionContext : NhSessionContext
{
    public static readonly AsyncNhSessionContext Instance = new();

    private static readonly AsyncLocal<NhSession?> CurrentSessionContainer = new(null);

    private AsyncNhSessionContext()
    {
    }

    public override NhSession CurrentSession
    {
        get => CurrentSessionContainer.Value ?? throw new InvalidOperationException("No DbSession");
        set
        {
            if (CurrentSessionContainer.Value is not null)
                throw new InvalidOperationException($"{nameof(NhSession)} is already set");

            CurrentSessionContainer.Value = value;
        }
    }

    public override NhSession ClearCurrentSession()
    {
        var nhSession = CurrentSessionContainer.Value;
        if (nhSession is null)
            throw new InvalidOperationException("No open session");
        
        CurrentSessionContainer.Value = null;

        return nhSession;
    }
}