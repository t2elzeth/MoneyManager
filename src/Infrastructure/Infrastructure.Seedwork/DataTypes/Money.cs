using CSharpFunctionalExtensions;

namespace Infrastructure.Seedwork.DataTypes;

public class Money : ValueObject<Money>
{
    private const byte AmountDecimals = 2;

    public decimal Amount { get; init; }
    
    public string Currency { get; init; } = null!;

    public decimal BaseAmount { get; set; }

    protected Money()
    {
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return obj.GetType() == GetType() && Equals((Money)obj);
    }

    protected override bool EqualsCore(Money other)
    {
        return Equals(Currency, other.Currency) && Amount == other.Amount;
    }

    protected override int GetHashCodeCore()
    {
        return HashCode.Combine(Amount, Currency);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (int.Parse(Currency) * 397) ^ Amount.GetHashCode();
        }
    }

    public static Money FromPair(decimal amount,
                                 string currency,
                                 decimal baseAmount)
    {
        if (amount < 0)
            throw new ArgumentException($"Amount must be positive ({amount})");

        if (baseAmount < 0)
            throw new ArgumentException($"BaseAmount must be positive ({baseAmount})");

        amount     = Truncate(amount, AmountDecimals);
        baseAmount = Truncate(baseAmount, AmountDecimals);

        return new Money
        {
            Amount     = amount,
            Currency   = currency,
            BaseAmount = baseAmount
        };
    }
    
    public static Money FromAmount(decimal amount,
                                   string currency,
                                   decimal rate)
    {
        if (amount < 0)
            throw new ArgumentException($"Amount must be positive ({amount})");

        if (rate <= 0)
            throw new ArgumentException($"Rate must be greater than zero ({rate})");

        amount = Truncate(amount, AmountDecimals);

        var baseAmount = Truncate(rate * amount, AmountDecimals);

        return new Money
        {
            Amount     = amount,
            Currency   = currency,
            BaseAmount = baseAmount
        };
    }


    public static Money Kgs(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException($"Amount must be positive ({amount})");

        amount = Truncate(amount, AmountDecimals);

        return new Money
        {
            Amount     = amount,
            Currency   = Currencies.KGS,
            BaseAmount = amount
        };
    }


    public static bool operator ==(Money money, decimal amount)
    {
        return money.Amount == amount;
    }

    public static bool operator !=(Money money, decimal amount)
    {
        return money.Amount != amount;
    }

    public static bool operator ==(Money money, string currency)
    {
        return money.Currency == currency;
    }

    public static bool operator !=(Money money, string currency)
    {
        return money.Currency != currency;
    }

    public static bool operator >(Money money, decimal amount)
    {
        return money.Amount > amount;
    }

    public static bool operator <(Money money, decimal amount)
    {
        return money.Amount < amount;
    }

    public static bool operator >=(Money money, decimal amount)
    {
        return money.Amount >= amount;
    }

    public static bool operator <=(Money money, decimal amount)
    {
        return money.Amount <= amount;
    }

    private static decimal Truncate(decimal value, byte decimals)
    {
        var r = Math.Round(value, decimals, MidpointRounding.ToEven);

        if (value > 0m && r > value)
        {
            return r - new decimal(1, 0, 0, false, decimals);
        }

        if (value < 0m && r < value)
        {
            return r + new decimal(1, 0, 0, false, decimals);
        }

        return r;
    }
}