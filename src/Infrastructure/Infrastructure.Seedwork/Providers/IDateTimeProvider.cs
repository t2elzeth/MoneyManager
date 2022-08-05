using Infrastructure.Seedwork.DataTypes;

namespace Infrastructure.Seedwork.Providers;

public interface IDateTimeProvider
{
    UtcDateTime Now();

    Date Today();
}

public class DateTimeProvider : IDateTimeProvider
{
    public UtcDateTime Now()
    {
        return DateTime.UtcNow;
    }

    public Date Today()
    {
        var now = DateTime.UtcNow;

        return new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc);
    }
}