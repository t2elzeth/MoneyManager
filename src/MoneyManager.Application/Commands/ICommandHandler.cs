using System.Diagnostics;
using MoneyManager.DataTypes.Customer;

namespace MoneyManager.Application.Commands;

public interface ICommandHandler<in TCommand>
{
    Task<CommandHandlerResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public abstract class BaseCommandAsyncHandler<TCommand> : ICommandHandler<TCommand>
{
    public abstract Task<CommandHandlerResult> HandleAsync(TCommand command, CancellationToken cancellationToken);

    protected static CommandHandlerResult Success()
    {
        return CommandHandlerResult.Unit;
    }

    protected static CommandHandlerResult Success(object response)
    {
        return new CommandHandlerResult(response);
    }

    protected static CommandHandlerResult Error(object error, bool commitTransaction = true)
    {
        return new CommandHandlerResult(error, commitTransaction);
    }

    protected static CommandHandlerResult Error(string parameterName,
                                                string message,
                                                bool commitTransaction = true)
    {
        var error = new WalletError(parameterName, message);
        return new CommandHandlerResult(error, commitTransaction);
    }
}

public abstract class BaseCommandHandler<TCommand> : BaseCommandAsyncHandler<TCommand>
{
    [DebuggerStepThrough]
    public override Task<CommandHandlerResult> HandleAsync(TCommand request, CancellationToken cancellationToken)
    {
        var result = Handle(request, cancellationToken);
        return Task.FromResult(result);
    }

    protected abstract CommandHandlerResult Handle(TCommand command, CancellationToken cancellationToken);
}