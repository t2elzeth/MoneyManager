using System;
using System.Threading.Tasks;
using NHibernate;

namespace Infrastructure.Nh.Postgres;

public class DbTransaction : IDisposable, IAsyncDisposable
{
    private readonly ITransaction _transaction;

    public DbTransaction()
    {
        var currentSession = NhSession.Current;
        _transaction = currentSession.BeginTransaction();
    }

    public void Commit()
    {
        var currentSession = NhSession.Current;
        currentSession.Flush();

        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public void Dispose()
    {
        if (_transaction.IsActive)
            _transaction.Rollback();
    }

    public async ValueTask DisposeAsync()
    {
        if (_transaction.IsActive)
            await _transaction.RollbackAsync();
    }
}