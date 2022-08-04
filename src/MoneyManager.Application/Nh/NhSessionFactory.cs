using Infrastructure.Nh.Postgres;
using MoneyManager.Application.Nh.UserTypes;
using NHibernate;
using Environment = NHibernate.Cfg.Environment;

namespace MoneyManager.Application.Nh;

public static class NhSessionFactory
{
    public static ISessionFactory Instance { get; }

    static NhSessionFactory()
    {
        Instance = new SessionFactoryBuilder()
                   .Use(new UserTypesConvention())
                   .AddFluentMappingsFrom("ElPay.Application")
                   .ExposeConfiguration(cfg => cfg.SetProperty(Environment.Hbm2ddlKeyWords, "none"))
                   .Build();
    }
}