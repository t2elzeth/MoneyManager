using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace Infrastructure.Nh.Postgres.CustomNpgsql;

public class IntArrayType : IUserType
{
    bool IUserType.Equals(object x, object y)
    {
        return x.Equals(y);
    }

    public int GetHashCode(object x)
    {
        return x?.GetHashCode() ?? 0;
    }

    public virtual object? NullSafeGet(DbDataReader resultSet,
                                       string[] names,
                                       ISessionImplementor sessionImplementor,
                                       object owner)
    {
        var index = resultSet.GetOrdinal(names[0]);

        if (resultSet.IsDBNull(index))
        {
            return null;
        }

        if (resultSet.GetValue(index) is int[] res)
        {
            return res.ToList();
        }

        throw new InvalidOperationException($"Cannot get {index} column value, it's null or not string array");
    }

    public virtual void NullSafeSet(DbCommand cmd,
                                    object? value,
                                    int index,
                                    ISessionImplementor sessionImplementor)
    {
        var parameter = (IDbDataParameter)cmd.Parameters[index];
        if (value == null)
        {
            parameter.Value = DBNull.Value;
        }
        else
        {
            var list = (IList<int>)value;
            parameter.Value = list.ToArray();
        }
    }

    public object DeepCopy(object value)
    {
        return value;
    }

    public object Replace(object original, object target, object owner)
    {
        return original;
    }

    public object Assemble(object cached, object owner)
    {
        return cached;
    }

    public object Disassemble(object value)
    {
        return value;
    }

    public SqlType[] SqlTypes
    {
        get
        {
            var sqlTypes = new SqlType[]
            {
                new NpgsqlExtendedSqlType(DbType.Object,
                                          NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Integer
                                         )
            };

            return sqlTypes;
        }
    }

    public virtual System.Type ReturnedType => typeof(IList<int>);

    public bool IsMutable { get; }
}