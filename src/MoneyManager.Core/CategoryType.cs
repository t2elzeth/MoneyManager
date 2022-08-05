using Infrastructure.Seedwork.DataTypes;

namespace MoneyManager.Core;

public class CategoryType : EnumObject
{
    private const string IncomeKey = "INC";
    private const string OutcomeKey = "OUT";

    public static CategoryType Income = new(IncomeKey, "Доход");
    public static CategoryType Outcome = new(OutcomeKey, "Расход");

    private CategoryType(string key, string name) : base(key, name)
    {
    }
}