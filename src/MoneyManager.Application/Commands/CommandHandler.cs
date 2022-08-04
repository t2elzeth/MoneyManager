using System.Diagnostics;
using Autofac;
using Infrastructure.Nh.Postgres;
using NHibernate;

namespace MoneyManager.Application.Commands;

public class CommandHandler
{
    private static readonly ILogger Logger = LoggerFactory.Create<CommandHandler>();

    private readonly ISessionFactory _sessionFactory;
    private readonly ILifetimeScope _serviceFactory;

    public CommandHandler(ISessionFactory sessionFactory,
        ILifetimeScope serviceFactory)
    {
        _sessionFactory = sessionFactory;
        _serviceFactory = serviceFactory;
    }

    public async Task<CommandHandlerResult> HandleAsync<TRequest>(TRequest request)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

        return await HandleAsync(request, cts.Token);
    }

    public async Task<CommandHandlerResult> HandleAsync<TRequest>(TRequest request, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();

        await using var session = NhSession.Bind(_sessionFactory);
        await using var dbTransaction = new DbTransaction();

        var commandHandler = _serviceFactory.Resolve<ICommandHandler<TRequest>>();
        var result = await commandHandler.HandleAsync(request, cancellationToken);

        if (result.CommitTransaction)
            dbTransaction.Commit();

        stopwatch.Stop();

        if (Logger.IsDebugEnabled)
            Logger.Info("Processing of command {Command} took {Time}", typeof(TRequest).Name, stopwatch.Elapsed);

        return result;
    }
}