using System;
using System.Data;
using Dapper;
using Infrastructure.DataTypes;

namespace Infrastructure.Nh.Postgres.Dapper;

public class KgDateTimeHandler : SqlMapper.TypeHandler<KgDateTime>
{
    public override void SetValue(IDbDataParameter parameter,
                                  KgDateTime dateTime)
    {
        parameter.Value = dateTime.Value;
    }

    public override KgDateTime Parse(object value)
    {
        var dateTime = (DateTime)value;

        return new DateTime(dateTime.Year,
                            dateTime.Month,
                            dateTime.Day,
                            dateTime.Hour,
                            dateTime.Minute,
                            dateTime.Second,
                            dateTime.Millisecond,
                            DateTimeKind.Local);
    }
}