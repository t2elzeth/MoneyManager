using System;
using System.Globalization;
using CSharpFunctionalExtensions;

namespace Infrastructure.DataTypes;

public class UtcDateTime : SingleValueObject<DateTime>
{
    private const string Format = "yyyy-MM-ddTHH:mm:ssZ";

    public static UtcDateTime Now => new(DateTime.UtcNow);

    public static UtcDateTime Today
    {
        get
        {
            var now = DateTime.UtcNow;

            return new UtcDateTime(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc));
        }
    }

    private UtcDateTime(DateTime value)
        : base(value)
    {
    }

    public static implicit operator DateTime(UtcDateTime value)
    {
        return value.Value;
    }
    
    public static implicit operator UtcDateTime(KgDateTime? value)
    {
        if (value is null)
            return null!;

        return value.Value;
    }
    
    public static implicit operator UtcDateTime(GmtDateTime? value)
    {
        if (value is null)
            return null!;

        return value.Value.ToUniversalTime();
    }

    public static implicit operator string(UtcDateTime value)
    {
        return value.Value.ToString(Format);
    }

    public static implicit operator UtcDateTime(string value)
    {
        var result = Create(value);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Message);

        return result.Value;
    }

    public static implicit operator UtcDateTime(DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Unspecified)
            throw new InvalidOperationException($"Wrong DateTime {dateTime:yyyy.MM.dd HH:mm:ss fffffff}, DateTime.Kind is unspecified");

        var universalTime = dateTime.ToUniversalTime();

        return new UtcDateTime(universalTime);
    }

    public static UtcDateTime operator +(UtcDateTime utcDateTime, TimeSpan timeSpan)
    {
        return utcDateTime.Value + timeSpan;
    }

    public static UtcDateTime operator -(UtcDateTime utcDateTime, TimeSpan timeSpan)
    {
        return utcDateTime.Value - timeSpan;
    }

    public static Result<UtcDateTime, SystemError> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return SystemError.FillField;

        if (!DateTime.TryParse(value,
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal,
                               out var dateTime))
        {
            return SystemError.WrongFormat;
        }

        return new UtcDateTime(dateTime);
    }
}