namespace MoneyManager.DataTypes.BlackList;

public enum BlackListCheckStatus
{
    NotFound = 1,
    BlackListed = 2,
    HighRisk = 3,
}

public enum AutomaticHighRiskReason
{
    MonitoringList = 1,
    Country = 2,
    Pep = 3
}

public class BlackListCheckResult
{
    public BlackListCheckStatus Status { get; set; }

    public string? FullName { get; set; }

    public AutomaticHighRiskReason? HighRiskReason { get; set; }

    public static BlackListCheckResult BlackListed(string fullName)
    {
        return new BlackListCheckResult
        {
            Status   = BlackListCheckStatus.BlackListed,
            FullName = fullName,
        };
    }

    public static BlackListCheckResult FinMonitoring(AutomaticHighRiskReason automaticHighRiskReason, string? fullName)
    {
        return new BlackListCheckResult
        {
            Status         = BlackListCheckStatus.HighRisk,
            HighRiskReason = automaticHighRiskReason,
            FullName       = fullName
        };
    }

    public static BlackListCheckResult NotFound()
    {
        return new BlackListCheckResult
        {
            Status = BlackListCheckStatus.NotFound
        };
    }
}