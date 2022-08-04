using System.Collections.Generic;

namespace MoneyManager.DataTypes.API.Withdrawal;

public class WithdrawalWidgetResult
{
    public string PaymentServiceName { get; }

    public long WithdrawalRequestId { get; }

    public string WidgetType { get; }

    public IDictionary<string, object> Widget { get; }

    public WithdrawalWidgetResult(string paymentServiceName,
                                  long withdrawalRequestId,
                                  string widgetType,
                                  IDictionary<string, object> widget)
    {
        PaymentServiceName  = paymentServiceName;
        WithdrawalRequestId = withdrawalRequestId;
        WidgetType          = widgetType;
        Widget              = widget;
    }
}