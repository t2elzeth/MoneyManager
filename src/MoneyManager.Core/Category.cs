namespace MoneyManager.Core;

public class Category
{
    public virtual long Id { get; set; }

    public virtual CategoryType Type { get; set; } = null!;

    public virtual string Name { get; set; } = null!;
}