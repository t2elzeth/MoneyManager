using System.Text.Json.Serialization;
using Infrastructure.Seedwork.Validation;

namespace Infrastructure.Seedwork.DataTypes;

public class ErrorResult
{
    public long? Code { get; set; }

    public string? Message { get; set; }

    public Dictionary<string, string>? ParameterErrors { get; private set; }

    public ErrorResult()
    {
    }

    [JsonConstructor]
    public ErrorResult(long? code,
                       string? message,
                       Dictionary<string, string>? parameterErrors)
    {
        Code            = code;
        Message         = message;
        ParameterErrors = parameterErrors;
    }

    public ErrorResult SetParameterError(string parameterName, string errorMessage)
    {
        ParameterErrors ??= new Dictionary<string, string>();

        ParameterErrors[parameterName] = errorMessage;

        return this;
    }

    public static implicit operator ErrorResult(SystemError error)
    {
        return new ErrorResult
        {
            Message = error.Message
        };
    } 
}