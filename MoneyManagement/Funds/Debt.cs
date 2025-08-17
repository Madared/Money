using MoneyManagement.Currencies;
using MoneyManagement.Decimals;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds;

public abstract class Debt : INonPositiveFunds
{
    public abstract NegativeDecimal DebtAmount { get; }
    decimal IFunds.Amount => DebtAmount.Amount;
    public abstract Currency Currency { get; }
    INonPositiveDecimal INonPositiveFunds.Amount => DebtAmount;
}