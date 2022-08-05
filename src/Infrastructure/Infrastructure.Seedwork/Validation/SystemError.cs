namespace Infrastructure.Seedwork.Validation;

public class SystemErrorMessage
{
    public static readonly SystemErrorMessage InternalSystemError = new("Внутренняя ошибка системы");
    
    public string Message { get; }

    public SystemErrorMessage(string message)
    {
        Message = message;
    }
}

public class SystemError
{
    public const string FillFieldMessage = "Заполните поле";
    public const string WrongFormatMessage = "Неверный формат";

    public static readonly SystemError FillField = new(FillFieldMessage);
    public static readonly SystemError WrongFormat = new(WrongFormatMessage);

    public string? Message { get; set; }

    public IDictionary<string, string>? ParameterErrors { get; set; }

    public SystemError()
    {
    }

    protected SystemError(string message)
    {
        Message = message;
    }

    protected SystemError(IDictionary<string, string> parameterErrors)
    {
        ParameterErrors = parameterErrors;
    }

    public static implicit operator SystemError(SystemErrorMessage errorMessage)
    {
        return new SystemError(errorMessage.Message);
    }
}