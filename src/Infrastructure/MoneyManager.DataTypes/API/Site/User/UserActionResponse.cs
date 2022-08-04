using Newtonsoft.Json;

namespace MoneyManager.DataTypes.API.Site.User;

public enum UserResponseStatus
{
    Success = 0,
    UserNotFound = 1,
    NameIsRequired = 2,
    SurnameIsRequired = 3,
    PasswordIsRequired = 2,
    UserCategoryNotFound = 6,
    UserIsAlreadyVerified = 7,
    UserBlacklisted = 8,
    VerificationRequestIsNotFound = 9,
    VerificationRequestIsAlreadyUsed = 10,
    ImageValidationFailure = 11
}

public class UserActionResponse
{
    public UserResponseStatus Status { get; set; }

    public string? BlacklistUserName { get; set; }

    public string? ErrorMessage { get; set; }

    [JsonConstructor]
    protected UserActionResponse()
    {
    }

    protected UserActionResponse(UserResponseStatus status)
    {
        Status = status;
    }

    public static implicit operator UserActionResponse(UserResponseStatus status)
    {
        return new UserActionResponse(status);
    }

    public static UserActionResponse Blacklisted(string blackListUserName)
    {
        return new UserActionResponse(UserResponseStatus.UserBlacklisted)
        {
            BlacklistUserName = blackListUserName
        };
    }

    public static UserActionResponse ImageValidationFailure(string errorMessage)
    {
        return new UserActionResponse(UserResponseStatus.ImageValidationFailure)
        {
            ErrorMessage = errorMessage
        };
    }
}

public class UserActionResponse<TPayload> : UserActionResponse
    where TPayload : class
{
    public TPayload? Payload { get; set; }

    [JsonConstructor]
    protected UserActionResponse()
    {
    }

    private UserActionResponse(UserResponseStatus status)
        : base(status)
    {
    }

    public static implicit operator UserActionResponse<TPayload>(UserResponseStatus status)
    {
        return new UserActionResponse<TPayload>(status);
    }

    public static implicit operator UserActionResponse<TPayload>(TPayload payload)
    {
        return new UserActionResponse<TPayload>(UserResponseStatus.Success)
        {
            Payload = payload
        };
    }
}