namespace MoneyManager.DataTypes.API.KioskWithdrawal;

public class KioskWithdrawalRequestDTO
{
    public long Id { get; set; }

    public decimal Amount { get; set; }

    public decimal ProviderAmount { get; set; }

    public string SecretCode { get; set; } = null!;

    public string UserLogin { get; set; } = null!;
}