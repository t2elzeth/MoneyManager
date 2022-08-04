namespace MoneyManager.DataTypes.API.Withdrawal;

public class ConfirmWithdrawalRequest
{
    public long WithdrawalRequestId { get; set; }

    public long UserId { get; set; }

    public string Password { get; set; } = null!;

    public static ConfirmWithdrawalRequest Create(long withdrawalRequestId,
                                                  long userId,
                                                  string password)
    {
        return new ConfirmWithdrawalRequest
        {
            WithdrawalRequestId = withdrawalRequestId,
            UserId              = userId,
            Password            = password
        };
    }
}