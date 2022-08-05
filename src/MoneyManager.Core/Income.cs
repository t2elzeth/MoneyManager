using Infrastructure.Seedwork.DataTypes;

namespace MoneyManager.Core;

public class Income
{
    public virtual long Id { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual decimal Amount { get; set; }

    public UtcDateTime CreateDateTime { get; set; } = null!;
}