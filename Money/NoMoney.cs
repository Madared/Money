using Money.Currencies;

namespace Money;

public record NoMoney(Currency Currency) : INonNegativeFunds, INonPositiveFunds {
    decimal IFunds.Amount => 0M;
}