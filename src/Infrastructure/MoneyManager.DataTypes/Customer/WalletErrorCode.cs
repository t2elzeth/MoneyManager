namespace MoneyManager.DataTypes.Customer;

public enum WalletErrorCode
{
    //withdrawal errors
    UserAgreementIsNotAccepted = 1,

    PaymentServiceUnavailable = 1000,
    ThereIsActiveWithdrawal = 1001
}