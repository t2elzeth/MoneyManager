namespace MoneyManager.Application.Commands;

public class CommandHandlerResult
{
    public static readonly CommandHandlerResult Unit = new(new object());

    public bool IsFailure => _error is not null;

    public bool CommitTransaction { get; }

    private readonly object? _error;
    public object Error => _error ?? throw new InvalidOperationException("No error");

    private readonly object? _response;
    public object Response => _response ?? throw new InvalidOperationException("Response has error");

    public CommandHandlerResult(object error, bool commitTransaction)
    {
        CommitTransaction = commitTransaction;
        _error            = error;
    }

    public CommandHandlerResult(object response)
    {
        CommitTransaction = true;
        _response         = response;
    }
}