namespace MoneyManager.DataTypes.API.Withdrawal;

public class PayResponseDTO
{
    public bool IsSuccess { get; set; }
        
    public string? ErrorMessage { get; set; }
}