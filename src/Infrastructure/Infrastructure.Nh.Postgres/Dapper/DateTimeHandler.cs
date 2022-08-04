using System;
using System.Data;
using Dapper;

namespace Infrastructure.Nh.Postgres.Dapper;

public abstract class DateTimeHandler : SqlMapper.TypeHandler<DateTime>
{
    private readonly DateTimeKind _kind;

    protected DateTimeHandler(DateTimeKind kind)
    {
        _kind = kind;
    }

    public override void SetValue(IDbDataParameter parameter,
                                  DateTime value)
    {
        parameter.Value = value;
    }

    public override DateTime Parse(object value)
    {
        return DateTime.SpecifyKind((DateTime) value, _kind);
    }
}