using System;
using Infrastructure.DataTypes;
using NHibernate;
using NHibernate.Type;

namespace Infrastructure.Nh.Postgres.Conventions.UserTypes;

public sealed class KgDateTimeUserType : SingleValueObjectType<KgDateTime>
{
    protected override NullableType PrimitiveType => NHibernateUtil.LocalDateTime;

    protected override KgDateTime Create(object value)
    {
        return Convert.ToDateTime(value);
    }

    protected override object GetValue(KgDateTime kgDateTime)
    {
        return kgDateTime.Value;
    }
}