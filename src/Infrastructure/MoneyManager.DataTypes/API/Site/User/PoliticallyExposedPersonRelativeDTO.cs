namespace MoneyManager.DataTypes.API.Site.User;

public class PoliticallyExposedPersonRelativeDTO
{
    public bool Flag { get; set; }

    public string Relation { get; set; } = null!;

    public string PositionAndPeriod { get; set; } = null!;
}