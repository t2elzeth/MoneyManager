using System;
using System.Data;
using System.Threading.Tasks;
using Infrastructure.Nh.Postgres.Contexts;
using NHibernate;

namespace Infrastructure.Nh.Postgres;

public class NhSession : IDisposable, IAsyncDisposable
{
    private static NhSessionContext? _context;

    public static NhSessionContext Context
    {
        get => _context ??= AsyncNhSessionContext.Instance;
        set
        {
            if (_context is not null)
                throw new InvalidOperationException("Context is already set");

            _context = value;
        }
    }

    public static ISession Current => Context.CurrentSession.Session;
    public static IDbConnection CurrentConnection => Current.Connection;

    public ISession Session { get; }

    private NhSession(ISession session)
    {
        Session = session;
    }

    public static NhSession Bind(ISessionFactory sessionFactory)
    {
        var session = sessionFactory.OpenSession();

        var nhSession = new NhSession(session);

        Context.CurrentSession = nhSession;

        return nhSession;
    }

    public void Dispose()
    {
        Context.ClearCurrentSession();
        Session.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        Context.ClearCurrentSession();
        Session.Dispose();

        return default;
    }
}