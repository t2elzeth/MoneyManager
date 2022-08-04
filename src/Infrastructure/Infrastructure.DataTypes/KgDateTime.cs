using System;
using System.Globalization;
using CSharpFunctionalExtensions;

namespace Infrastructure.DataTypes;

public class KgDateTime : SingleValueObject<DateTime>
{
    private const string Format = "yyyy-MM-ddTHH:mm:ss zzz";

    public static KgDateTime Now => DateTime.Now;

    public static KgDateTime Today
    {
        get
        {
            var now = DateTime.Now;

            return new KgDateTime(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Local));
        }
    }

    public static KgDateTime Yesterday
    {
        get
        {
            var yesterday = DateTime.Now.AddDays(-1);

            return new KgDateTime(new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 0, 0, 0, DateTimeKind.Local));
        }
    }

    private KgDateTime(DateTime value)
        : base(value)
    {
    }

    public static implicit operator DateTime(KgDateTime value)
    {
        return value.Value;
    }

    public static implicit operator DateTime?(KgDateTime? value)
    {
        return value?.Value;
    }

    public static implicit operator string(KgDateTime value)
    {
        return value.Value.ToString(Format);
    }

    public static implicit operator KgDateTime(string value)
    {
        var result = Create(value);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Message);

        return result.Value;
    }

    public static implicit operator KgDateTime(DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Unspecified)
            throw new InvalidOperationException($"Wrong DateTime {dateTime:yyyy.MM.dd HH:mm:ss fffffff}, DateTime.Kind is unspecified");

        var localTime = dateTime.ToLocalTime();

        return new KgDateTime(localTime);
    }

    public static implicit operator KgDateTime(UtcDateTime? value)
    {
        if (value is null)
            return null!;

        return value.Value.ToLocalTime();
    }

    public static implicit operator KgDateTime(GmtDateTime? value)
    {
        if (value is null)
            return null!;

        return new KgDateTime(value.Value);
    }


    public static KgDateTime operator +(KgDateTime kgDateTime, TimeSpan timeSpan)
    {
        return kgDateTime.Value + timeSpan;
    }

    public static KgDateTime operator -(KgDateTime kgDateTime, TimeSpan timeSpan)
    {
        return kgDateTime.Value - timeSpan;
    }

    public static bool operator <=(KgDateTime? kgDateTime, KgDateTime other)
    {
        if (kgDateTime is null)
            return false;

        return kgDateTime.Value <= other.Value;
    }

    public static bool operator >=(KgDateTime? kgDateTime, KgDateTime other)
    {
        if (kgDateTime is null)
            return false;

        return kgDateTime.Value >= other.Value;
    }

    public static bool operator <=(KgDateTime kgDateTime, DateTime other)
    {
        return kgDateTime.Value <= other;
    }

    public static bool operator >=(KgDateTime kgDateTime, DateTime other)
    {
        return kgDateTime.Value >= other;
    }

    public static Result<KgDateTime, SystemError> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return SystemError.FillField;

        if (!DateTime.TryParse(value,
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.AssumeLocal,
                               out var dateTime))
        {
            return SystemError.WrongFormat;
        }

        return new KgDateTime(dateTime);
    }
}