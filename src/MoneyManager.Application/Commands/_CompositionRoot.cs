using Autofac;
using JetBrains.Annotations;

namespace MoneyManager.Application.Commands;

[UsedImplicitly]
internal class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CommandHandler>().SingleInstance();
    }
}