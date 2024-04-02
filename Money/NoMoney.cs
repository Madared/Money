using System.Security.Cryptography.X509Certificates;
using Money.Currencies;
using Money.Decimals;

namespace Money;

public record NoMoney(Currency Currency) : INonNegativeFunds, INonPositiveFunds {
    decimal IFunds.Amount => 0M;
    INonNegativeDecimal INonNegativeFunds.Amount => new ZeroDecimal();
    INonPositiveDecimal INonPositiveFunds.Amount => new ZeroDecimal();
}