using System.Collections.Generic;

namespace MoneyManager.DataTypes.API.Withdrawal;

public class CheckWithdrawalFieldsRequest
{
    public long WithdrawalRequestId { get; }

    public long UserId { get; }

    public long PaymentServiceId { get; }

    public IDictionary<string, object> FieldValues { get; }

    public CheckWithdrawalFieldsRequest(long withdrawalRequestId,
                                        long userId,
                                        long paymentServiceId,
                                        IDictionary<string, object> fieldValues)
    {
        WithdrawalRequestId = withdrawalRequestId;
        UserId              = userId;
        PaymentServiceId    = paymentServiceId;
        FieldValues         = fieldValues;
    }
}

public class CheckWithdrawalFieldsResult
{
    public long ProviderCurrencyId { get; set; }

    public decimal ProviderSum { get; set; }

    public IDictionary<string, object>? Widget { get; set; }

    public static CheckWithdrawalFieldsResult Create(long providerCurrencyId,
                                                     decimal providerSum,
                                                     IDictionary<string, object> widget)
    {
        return new CheckWithdrawalFieldsResult
        {
            ProviderCurrencyId = providerCurrencyId,
            ProviderSum        = providerSum,
            Widget             = widget
        };
    }

    public static CheckWithdrawalFieldsResult Create(long providerCurrencyId,
                                                     decimal providerSum)
    {
        return new CheckWithdrawalFieldsResult
        {
            ProviderCurrencyId = providerCurrencyId,
            ProviderSum        = providerSum
        };
    }
}