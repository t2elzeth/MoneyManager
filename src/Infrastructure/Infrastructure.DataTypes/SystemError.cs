using System.Collections.Generic;

namespace Infrastructure.DataTypes;

public class SystemError
{
    public const string FillFieldMessage = "Заполните поле";
    public const string InternalSystemErrorMessage = "Внутренняя ошибка системы";

    public static readonly SystemError FillField = new(FillFieldMessage);
    public static readonly SystemError WrongFormat = new("Неверный формат");
    public static readonly SystemError InternalSystemError = new(InternalSystemErrorMessage);


    public string? Message { get; set; }

    public IDictionary<string, string>? ParameterErrors { get; set; }

    public SystemError()
    {
    }

    protected SystemError(string message)
    {
        Message = message;
    }
}