using System.Text.Json.Serialization;
using CSharpFunctionalExtensions;
using Infrastructure.Seedwork.JsonConverters;
using Infrastructure.Seedwork.Validation;

namespace Infrastructure.Seedwork.DataTypes;

[JsonConverter(typeof(UserLoginJsonConverter))]
public class UserLogin : SingleValueObject<string>
{
    private UserLogin(string value)
        : base(value)
    {
    }

    public static explicit operator UserLogin(string value)
    {
        var result = Create(value);
        if (result.IsFailure)
            throw new InvalidOperationException(result.Error);

        return result.Value;
    }

    public static explicit operator string(UserLogin userLogin)
    {
        return userLogin.Value;
    }

    public static Result<UserLogin, string> Create(string? login)
    {
        if (string.IsNullOrWhiteSpace(login))
            return SystemError.FillFieldMessage;

        return new UserLogin(login);
    }
}