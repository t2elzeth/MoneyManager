using Infrastructure.DataTypes;

namespace MoneyManager.DataTypes.API.Site.User;

public class UserMigrationCardDTO
{
    public string Number { get; set; } = null!;

    public Date? StartDate { get; set; }

    public Date? EndDate { get; set; }
}