using System;
using System.Threading.Tasks;
using Infrastructure.Nh.Postgres;
using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;

namespace Infrastructure.AspNetCore.Nh;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class NhSessionAttribute : Attribute
{
}

public class NhSessionAttributeActionFilter : IAsyncActionFilter
{
    private readonly ISessionFactory _sessionFactory;

    public NhSessionAttributeActionFilter(ISessionFactory sessionFactory)
    {
        _sessionFactory = sessionFactory;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                             ActionExecutionDelegate next)
    {
        if (!context.ActionDescriptor.IsControllerAction())
        {
            await next();
            return;
        }

        var attribute = AttributeProvider<NhSessionAttribute>.FirstOrDefault(context.ActionDescriptor.GetMethodInfo());

        if (attribute == null)
        {
            await next();
            return;
        }

        using var session = _sessionFactory.OpenSession();

        await using (NhSession.Bind(_sessionFactory))
        {
            await next();
        }
    }
}