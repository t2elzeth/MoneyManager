using System;
using System.Data;
using Dapper;
using Infrastructure.DataTypes;

namespace Infrastructure.Nh.Postgres.Dapper;

public class DateHandler : SqlMapper.TypeHandler<Date>
{
    public override void SetValue(IDbDataParameter parameter,
                                  Date dateTime)
    {
        parameter.Value = dateTime.Value;
    }

    public override Date Parse(object value)
    {
        return (DateTime)value;
    }
}