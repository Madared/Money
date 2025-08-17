using MoneyManagement.Currencies;
using MoneyManagement.Decimals;

namespace MoneyManagement.Funds;

public abstract class NoMoney : INonNegativeFunds, INonPositiveFunds {
    decimal IFunds.Amount => 0M;
    public Currency Currency { get; }
    INonNegativeDecimal INonNegativeFunds.Amount => new ZeroDecimal();
    INonPositiveDecimal INonPositiveFunds.Amount => new ZeroDecimal();
}