using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Infrastructure.DataTypes;
using Infrastructure.Nh.Postgres.Conventions.UserTypes;

namespace Infrastructure.Nh.Postgres.Conventions;

public class UserTypesConvention : IPropertyConvention
{
    public void Apply(IPropertyInstance instance)
    {
        if (instance.Property.PropertyType == typeof(UtcDateTime))
            instance.CustomType<UtcDateTimeUserType>();

        if (instance.Property.PropertyType == typeof(KgDateTime))
            instance.CustomType<KgDateTimeUserType>();

        if (instance.Property.PropertyType == typeof(Date))
            instance.CustomType<DateUserType>();
    }
}