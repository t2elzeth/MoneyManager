using System;
using Infrastructure.DataTypes;
using NHibernate;
using NHibernate.Type;

namespace Infrastructure.Nh.Postgres.Conventions.UserTypes;

public class DateUserType : SingleValueObjectType<Date>
{
    protected override NullableType PrimitiveType { get; } = NHibernateUtil.LocalDateTime;

    protected override Date Create(object value)
    {
        return Convert.ToDateTime(value);
    }

    protected override object GetValue(Date date)
    {
        return date.Value;
    }
}