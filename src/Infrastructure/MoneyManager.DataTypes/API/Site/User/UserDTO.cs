using System;

namespace MoneyManager.DataTypes.API.Site.User;

public class UserDTO
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsBlocked { get; set; }

    public decimal Balance { get; set; }

    public DateTime RegistrationDate { get; set; }

    public CategoryDTO Category { get; set; } = null!;

    public UserFormDTO Form { get; set; } = null!;

    public DateTime? BlockTimestamp { get; set; }

    public string? ManualBlockComment { get; set; }

    public string? MatchedBlackListPerson { get; set; }

    public UserBlockReason? BlockReason { get; set; }
}