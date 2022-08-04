using System;
using Infrastructure.DataTypes;
using NHibernate;
using NHibernate.Type;

namespace Infrastructure.Nh.Postgres.Conventions.UserTypes;

public sealed class UtcDateTimeUserType : SingleValueObjectType<UtcDateTime>
{
    protected override NullableType PrimitiveType => NHibernateUtil.UtcDateTime;

    protected override UtcDateTime Create(object value)
    {
        var dateTime = Convert.ToDateTime(value);

        return dateTime;
    }

    protected override object GetValue(UtcDateTime utcDateTime)
    {
        return utcDateTime.Value;
    }
}