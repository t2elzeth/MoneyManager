using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Infrastructure.DataTypes;

namespace MoneyManager.Application.Nh.UserTypes;

public class UserTypesConvention : IPropertyConvention
{
    public void Apply(IPropertyInstance instance)
    {
        if (instance.Property.PropertyType == typeof(UtcDateTime))
            instance.CustomType<UtcDateTimeUserType>();
        
        if (instance.Property.PropertyType == typeof(KgDateTime))
            instance.CustomType<KgDateTimeUserType>();
    }
}