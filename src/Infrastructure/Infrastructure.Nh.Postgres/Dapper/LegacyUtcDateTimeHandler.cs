using System;

namespace Infrastructure.Nh.Postgres.Dapper;

public class LegacyUtcDateTimeHandler : DateTimeHandler
{
    public LegacyUtcDateTimeHandler() : base(DateTimeKind.Utc)
    {
    }
}