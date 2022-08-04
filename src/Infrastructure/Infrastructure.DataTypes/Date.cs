using System;
using System.Globalization;
using CSharpFunctionalExtensions;

namespace Infrastructure.DataTypes;

public class Date : SingleValueObject<DateTime>
{
    private const string Format = "yyyy-MM-dd";

    public static Date Today => DateTime.Now.Date;

    private Date(DateTime value) : base(value)
    {
    }

    public override string ToString()
    {
        return Value.ToString(Format);
    }

    public Date AddMonths(int monthsNumber)
    {
        return Value.AddMonths(monthsNumber);
    }

    public static implicit operator Date(DateTime dateTime)
    {
        if (dateTime.Hour != 0 || dateTime.Minute != 0 || dateTime.Second != 0 || dateTime.Millisecond != 0)
            throw new InvalidOperationException($"Date must not contain time. DateTime: {dateTime:yyyy.MM.dd HH:mm:ss fffffff}");

        return new Date(dateTime.Date);
    }

    public static implicit operator Date(string value)
    {
        var result = Create(value);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Message);

        return result.Value;
    }

    public static bool operator <(Date value, Date otherValue)
    {
        return value.Value.Date < otherValue.Value.Date;
    }

    public static bool operator >(Date value, Date otherValue)
    {
        return value.Value.Date > otherValue.Value.Date;
    }

    public static bool operator <=(Date value, Date otherValue)
    {
        return value.Value.Date <= otherValue.Value.Date;
    }

    public static bool operator >=(Date value, Date otherValue)
    {
        return value.Value.Date >= otherValue.Value.Date;
    }

    public static Result<Date, SystemError> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return SystemError.FillField;

        if (!DateTime.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
        {
            return SystemError.WrongFormat;
        }

        return new Date(dateTime);
    }
}

public class GmtDateTime : SingleValueObject<DateTime>
{
    private const string Format = "yyyy-MM-dd HH:mm:ss zzz";

    private GmtDateTime(DateTime value) : base(value)
    {
    }

    public override string ToString()
    {
        return Value.ToString(Format);
    }

    public static implicit operator GmtDateTime(string value)
    {
        var result = Create(value);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error.Message);

        return result.Value;
    }

    public static Result<GmtDateTime, SystemError> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return SystemError.FillField;

        if (!DateTime.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
        {
            return SystemError.WrongFormat;
        }

        return new GmtDateTime(dateTime);
    }
}