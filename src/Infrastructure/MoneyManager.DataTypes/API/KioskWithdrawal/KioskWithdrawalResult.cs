namespace MoneyManager.DataTypes.API.KioskWithdrawal;

public enum KioskWithdrawalStatus
{
    Success = 0,
    WithdrawalIsNotFound = 1,
    WithdrawalIsNotActive = 2,
    HeldByAnotherKiosk = 3,
    NoHold = 4,
    LockedByKiosk = 5,
    UserIsBlocked = 6,
    NotEnoughMoney = 7,
    DailyLimitExceeds = 8,
    HasActiveWithdrawalRequest = 9
}

public class KioskWithdrawalResult
{
    public KioskWithdrawalStatus Status { get; }

    protected KioskWithdrawalResult(KioskWithdrawalStatus status)
    {
        Status = status;
    }

    public static implicit operator KioskWithdrawalResult(KioskWithdrawalStatus status)
    {
        return new KioskWithdrawalResult(status);
    }
}

public class KioskWithdrawalResult<TPayload> : KioskWithdrawalResult
{
    public TPayload? Payload { get; }

    private KioskWithdrawalResult(KioskWithdrawalStatus status, TPayload? payload)
        : base(status)
    {
        Payload = payload;
    }

    public static implicit operator KioskWithdrawalResult<TPayload>(KioskWithdrawalStatus status)
    {
        return new KioskWithdrawalResult<TPayload>(status, payload: default);
    }

    public static implicit operator KioskWithdrawalResult<TPayload>(TPayload payload)
    {
        return new KioskWithdrawalResult<TPayload>(KioskWithdrawalStatus.Success, payload);
    }
}