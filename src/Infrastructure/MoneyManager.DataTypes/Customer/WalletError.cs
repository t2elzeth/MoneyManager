using System;
using System.Collections.Generic;
using System.Globalization;
using Infrastructure.DataTypes;
using Newtonsoft.Json;

namespace MoneyManager.DataTypes.Customer;

public class WalletError : SystemError
{
    public const string ProveYourAreNotRobotMessage = "Докажите, что вы не робот";

    public const string UserIsNotFoundMessage = "Пользователь не найден";
    public const string PayerIsNotFoundMessage = "Плательщик не найден";
    public const string LoginIsAlreadyUsedMessage = "Логин уже занят";
    public const string InvalidPhoneNumberFormatMessage = "Неверный формат номера телефона";
    public const string EnterPasswordMessage = "Введите пароль";
    public const string EnterPasswordConfirmationMessage = "Введите подтверждение пароля";
    public const string EnterNewPasswordMessage = "Введите новый пароль";
    public const string PasswordsDoesNotMatchMessage = "Пароли не совпадают";
    public const string YouMustAcceptAgreement = "Необходимо Ваше согласие";
    public const string WrongPhoneNumberFormatMessage = "Неверный формат номера телефона";
    public const string UserProfileWrongEmailFormatMessage = "Неверный формат электронной почты";
    public const string EnterCodeConfirmationMessage = "Введите код подтверждения";
    public const string SumMustBeGreaterThanZeroMessage = "Введите сумму больше нуля";
    public const string NotEnoughMoneyMessage = "Недостаточно средств на балансе";
    public const string InvalidAccountNumberMessage = "Неправильный реквизит услуги";
    public const string PasswordRecoveryRequestIsNotFoundMessage = "Заявка на смену пароля не найдена";
    public const string WrongConfirmationCodeMessage = "Неверный код подтверждения";
    public const string SumIsTooSmallMessage = "Слишком маленькая сумма";
    public const string SumIsTooBigMessage = "Сумма слишком велика";
    public const string BadSumMessage = "Некорректная сумма платежа";
    public const string SelectSalepointMessage = "Выберите кассу";
    public const string SumMustBeOneKztAtLeastMessage = "Минимальный платеж - 1 тенге";
    public const string AccountIsNotFoundMessage = "Номер счета не найден";
    public const string InvalidPasswordMessage = "Неверный пароль";
    public const string WithdrawalAlreadyRefundedMessage = "Заявка на вывод уже возвращена";

    public const string UserIsBlockedMessage = "Пользователь заблокирован";
    public const string UserIsNotVerifiedMessage = "Пользователь не верифицирован";
    public const string PayerIsBlockedMessage = "Плательщик заблокирован";
    public const string PayerIsNotVerifiedMessage = "Плательщик не верифицирован";
    public const string OperationIsForbiddenMessage = "Данная операция недоступна";
    public const string EnterLoginOfOtherUserMessage = "Укажите номер кошелька другого пользователя";

    public const string InvoiceIsNotFoundMessage = "Инвойс не найден";

    public static readonly WalletError UserIsNotFound = new(UserIsNotFoundMessage);
    public static readonly WalletError PayerIsNotFound = new(PayerIsNotFoundMessage);
    public static readonly WalletError LoginIsAlreadyUsed = new(LoginIsAlreadyUsedMessage);
    public static readonly WalletError WrongConfirmationCode = new(WrongConfirmationCodeMessage);
    public static readonly WalletError CannotUpdateProfileUserIsAlreadyVerified = new("Невозможно изменить профиль, пользователь уже верифицирован");
    public static readonly WalletError CannotUpdateProfileUserProfile = new("Невозможно изменить профиль");

    public static readonly WalletError PasswordRecoveryRequestIsExpired = new("Время заявки на восстановление пароля истекло, создайте новую заявку");

    public static readonly WalletError UserRegistrationRequestIsExpired = new("Срок заявки на регистрацию истек, создайте новую заявку");
    public static readonly WalletError UserRegistrationIsDenied = new("Отказано в регистрации");
    public static readonly WalletError UserVerificationRequestIsNotFound = new("Не найдено запроса на верификацию");
    public static readonly WalletError UserVerificationRequestIsUsed = new("Запрос на верификацию уже использован");
    public static readonly WalletError UserIsAlreadyVerified = new("Пользователь уже верифицирован");

    public static readonly WalletError UserIsBlocked = new(UserIsBlockedMessage);
    public static readonly WalletError UserIsNotVerified = new(UserIsNotVerifiedMessage);
    public static readonly WalletError PayerIsBlocked = new(PayerIsBlockedMessage);
    public static readonly WalletError PayerIsNotVerified = new(PayerIsNotVerifiedMessage);
    public static readonly WalletError OperationIsAvailableForVerifiedUsers = new("Данная операция доступна только для верифицированных пользователей");
    public static readonly WalletError OperationIsForbidden = new(OperationIsForbiddenMessage);

    public static readonly WalletError NotEnoughMoney = new("Недостаточно средств на балансе");
    public static readonly WalletError SumMustBeGreaterThanZero = new(SumMustBeGreaterThanZeroMessage);

    public static readonly WalletError PasswordRecoveryRequestIsNotFound = new(PasswordRecoveryRequestIsNotFoundMessage);

    public static readonly WalletError UserNotificationIsNotFound = new("Пользовательское соглашение не найдено");
    public static readonly WalletError UserNotificationIsAlreadyAccepted = new("Пользовательское соглашение уже принято");
    public static readonly WalletError AcceptUserAgreement = new(WalletErrorCode.UserAgreementIsNotAccepted, "Примите пользовательское соглашение");

    public static readonly WalletError NewsItemIsNotFound = new("Новость не найдена");

    //invoice
    public static readonly WalletError InvoiceIsExpired = new("Инвойс просрочен. Пожалуйста, создайте новый.");
    public static readonly WalletError InvoiceIsAlreadyPaid = new("Счет уже оплачен");

    public static readonly WalletError InvalidLoginOrPassword = new("Неверный логин или пароль");

    //withdrawal errors
    public static readonly WalletError PaymentServiceUnavailable = new(WalletErrorCode.PaymentServiceUnavailable, "Сервис временно недоступен");
    public static readonly WalletError ThereIsActiveWithdrawal = new(WalletErrorCode.ThereIsActiveWithdrawal, "У Вас уже есть активная заявка");
    public static readonly WalletError PaymentDenied = new("Прием платежа запрещен, обратитесь к оператору");
    public static readonly WalletError ProviderDailyLimitExceeded = new("Превышен суточный лимит на сумму операций");
    public static readonly WalletError AccountIsInactive = new("Счет абонента не активен");
    public static readonly WalletError SelectSalepoint = new(SelectSalepointMessage);
    public static readonly WalletError WithdrawalRequestIsNotFound = new("Заявка на снятие не найдена");

    // Fin monitoring errors
    public static readonly WalletError FinMonitoringNotificationNotFound = new("Уведомление не найдено");
    public static readonly WalletError WrongResolveAction = new("Неправильный способ обработки финмониторинга");
    public static readonly WalletError FinMonitoringNotificationAlreadyApproved = new("Уже одобрено");
    public static readonly WalletError FinMonitoringNotificationAlreadyDeclined = new("Уже отменено");

    //salepoint errors
    public static readonly WalletError LowPaymentProviderBalance = new("Недостаточно средств на балансе поставщика. Обратитесь в тех.поддержку");
    public static readonly WalletError SalepointShiftIsNotFound = new("Смена не найдена");

    //back office errors
    public static readonly WalletError IdentityDocumentImageIsNotFound = new("Документ не найден");
    public static readonly WalletError BlackListNotFound = new("Черный список не найден");

    //User corrections
    public static readonly WalletError LoginIsNullOrWhitespace = new("Логин не может быть пустым");
    public static readonly WalletError CorrectionMustntBeZero = new("Сумма коррекции должна быть больше 0");
    public static readonly WalletError CommentIsNullOrWhitespace = new("Комментарий не может быть пустым");
    public static readonly WalletError UserCommentIsNullOrWhitespace = new("Комментарий пользователя не может быть пустым");

    //Emps
    public static readonly WalletError DuplicateOperation = new("Операция уже существует");

    public WalletErrorCode? Code { get; set; }

    [JsonConstructor]
    public WalletError()
    {
    }

    private WalletError(string message)
        : base(message)
    {
    }

    public WalletError(WalletErrorCode code)
    {
        Code = code;
    }

    public WalletError(WalletErrorCode code, string message)
        : base(message)
    {
        Code = code;
    }

    public WalletError(string parameterName, string message)
    {
        ParameterErrors = new Dictionary<string, string>
        {
            [parameterName] = message
        };
    }

    public WalletError(WalletErrorCode? code,
                       string? message,
                       IDictionary<string, string> parameterErrors)
    {
        Code            = code;
        Message         = message;
        ParameterErrors = parameterErrors;
    }

    public WalletError SetError(string parameterName, string errorMessage)
    {
        ParameterErrors ??= new Dictionary<string, string>();

        ParameterErrors[parameterName] = errorMessage;

        return this;
    }

    public static WalletError YouSendSMSTooOften(TimeSpan tryIn)
    {
        var strTryIn = tryIn.ToString(@"mm\:ss");

        return new WalletError($"Вы слишком часто отправляете СМС, попробуйте через {strTryIn}");
    }

    public static string PasswordMinimumLengthGuardMessage(long passwordMinLength)
    {
        return $"Пароль должен быть не менее {passwordMinLength} символов";
    }

    public static WalletError YouCanChangeVerificationMethodIn(TimeSpan tryIn)
    {
        var strTryIn = tryIn.ToString(@"mm\:ss");

        return new WalletError($"Смена способа верификации будет доступна через {strTryIn}");
    }

    public static WalletError DailyLimitExceeded(decimal remainder)
    {
        return new WalletError($"Доступная сумма для снятия {remainder:F2} тенге");
    }

    public static WalletError SumMultiplicityError(string parameterName, IList<decimal> availableSums)
    {
        var message = availableSums.Count == 1
            ? $"Укажите кратную сумму (например: {availableSums[0]})"
            : $"Укажите кратную сумму (например: {availableSums[0]} или {availableSums[1]})";

        return new WalletError(parameterName, message);
    }

    public static WalletError MinKzSumIsExceeded(decimal minSumKz)
    {
        return new WalletError(MinSumKzIsExceededMessage(minSumKz));
    }

    public static string MinSumKzIsExceededMessage(decimal minSumKz)
    {
        var sum = minSumKz.ToString("F2", CultureInfo.InvariantCulture);
        return $"Минимальная сумма: {sum} тг.";
    }

    public static WalletError MaxKzSumIsExceeded(decimal maxSumKz)
    {
        return new WalletError(MaxKzSumIsExceededMessage(maxSumKz));
    }

    public static string MaxKzSumIsExceededMessage(decimal maxSumKz)
    {
        var sum = maxSumKz.ToString("F2", CultureInfo.InvariantCulture);

        return $"Максимальная сумма: {sum} тг.";
    }

    public static WalletError UserIsBlackListed(string login)
    {
        return new WalletError($"Операция отклонена. Клиент {login} в черном списке.");
    }

    public static WalletError PayerIsBlackListed(string blackListedPerson)
    {
        return new WalletError($"Операция отклонена. Плательщик {blackListedPerson} в черном списке");
    }

    public static WalletError FileFormatIsNotSupported(string documentSide)
    {
        return new WalletError($"Неудалось загрузить документ '{documentSide}', формат не поддерживается");
    }

    public static WalletError SumIsTooLow(decimal minLimit)
    {
        var minLimitString = minLimit.ToString("G", CultureInfo.InvariantCulture);

        return new WalletError($"Операция отклонена. Слишком маленькая сумма (минимальный лимит: {minLimitString})");
    }

    public static WalletError SumIsTooHigh(decimal maxLimit)
    {
        var maxLimitString = maxLimit.ToString("G", CultureInfo.InvariantCulture);

        return new WalletError($"Операция отклонена. Доступный лимит {maxLimitString} сомов");
    }
}