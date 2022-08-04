using Autofac;
using JetBrains.Annotations;
using MoneyManager.Commons.Network;

namespace MoneyManager.Commons;

[UsedImplicitly]
public class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HttpClient>()
               .As<IHttpClient>();
    }
}