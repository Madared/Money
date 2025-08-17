using MoneyManagement.Currencies;
using MoneyManagement.Decimals;
using ResultAndOption;
using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds;

public abstract class Money(PositiveDecimal CashAmount, Currency Currency) : INonNegativeFunds
{
    public abstract PositiveDecimal CashAmount { get; }
    public abstract Currency Currency { get; }
    decimal IFunds.Amount => CashAmount.Amount;
    INonNegativeDecimal INonNegativeFunds.Amount => CashAmount;
}