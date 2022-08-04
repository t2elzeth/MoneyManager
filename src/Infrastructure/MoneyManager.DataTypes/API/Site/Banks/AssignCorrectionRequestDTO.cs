namespace MoneyManager.DataTypes.API.Site.Banks;

public class AssignCorrectionRequestDTO
{
    public long BankId { get; set; }
        
    public long SubagentId { get; set; }
        
    public long CorrectionId { get; set; }
}