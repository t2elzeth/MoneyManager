using MoneyManager.Application.Commands;

namespace MoneyManager.Application.Category;

public class CreateCategoryCommand
{
}

public class CreateCategoryHandler : BaseCommandHandler<CreateCategoryCommand>
{
    protected override CommandHandlerResult Handle(CreateCategoryCommand command,
                                                   CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}