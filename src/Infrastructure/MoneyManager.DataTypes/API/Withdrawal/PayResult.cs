namespace MoneyManager.DataTypes.API.Withdrawal;

public enum PayWithdrawalStatus
{
    InProgress = 1,
    Paid = 2,
    Refund = 3
}

public class PayResult
{
    public static readonly PayResult InProgress = new() { Status = PayWithdrawalStatus.InProgress };
    public static readonly PayResult Paid = new() { Status       = PayWithdrawalStatus.Paid };
    public static readonly PayResult Refund = new() { Status     = PayWithdrawalStatus.Refund };

    public PayWithdrawalStatus Status { get; set; }
}