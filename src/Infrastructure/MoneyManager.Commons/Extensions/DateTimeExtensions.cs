using System;

namespace MoneyManager.Commons.Extensions;

public enum DateTimePart
{
    Year,
    Month,
    Day,
    Hour,
    Minute
}

public static class DateTimeExtensions
{
    private static readonly TimeZoneInfo AstanaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");

    public static DateTime StartOf(this DateTime dateTime, DateTimePart dateTimePart)
    {
        switch (dateTimePart)
        {
            case DateTimePart.Year:
                return new DateTime(dateTime.Year, 1, 1, 0, 0, 0, dateTime.Kind);

            case DateTimePart.Month:
                return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0, dateTime.Kind);

            case DateTimePart.Day:
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);

            case DateTimePart.Hour:
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Kind);

            case DateTimePart.Minute:
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Day, dateTime.Second, 0, dateTime.Kind);

            default:
                throw new ArgumentOutOfRangeException(nameof(dateTimePart), dateTimePart, null);
        }
    }

    public static DateTime EndOf(this DateTime dateTime, DateTimePart dateTimePart)
    {
        switch (dateTimePart)
        {
            case DateTimePart.Year:
                return new DateTime(dateTime.Year, 12, 31, 23, 59, 59, dateTime.Kind);

            case DateTimePart.Month:
                return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59, dateTime.Kind);

            case DateTimePart.Day:
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, dateTime.Kind);

            case DateTimePart.Hour:
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 59, 59, dateTime.Kind);

            case DateTimePart.Minute:
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Day, dateTime.Second, 59, dateTime.Kind);

            default:
                throw new ArgumentOutOfRangeException(nameof(dateTimePart), dateTimePart, null);
        }
    }

    public static DateTime SetTime(this DateTime dateTime,
                                   int hour,
                                   int minute,
                                   int second)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, second);
    }

    public static long UnixTime(this DateTime dateTime)
    {
        return (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
    }

    public static DateTime ToKgTimeZone(this DateTime dateTime)
    {
        return TimeZoneInfo.ConvertTime(dateTime, AstanaTimeZone);
    }

    public static DateTime AssumeLocal(this DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Unspecified)
        {
            return new DateTime(dateTime.Year, 
                                dateTime.Month, 
                                dateTime.Day, 
                                dateTime.Hour, 
                                dateTime.Minute, 
                                dateTime.Second,
                                DateTimeKind.Local);
        }

        return dateTime;
    }
    
    public static DateTime? AssumeLocal(this DateTime? dateTime)
    {
        if (dateTime is null)
            return null;
        
        if (dateTime.Value.Kind == DateTimeKind.Unspecified)
        {
            return new DateTime(dateTime.Value.Year, 
                                dateTime.Value.Month, 
                                dateTime.Value.Day, 
                                dateTime.Value.Hour, 
                                dateTime.Value.Minute, 
                                dateTime.Value.Second,
                                DateTimeKind.Local);
        }

        return dateTime;
    }
}