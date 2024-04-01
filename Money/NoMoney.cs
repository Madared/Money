using Money.Currencies;

namespace Money;

public record NoMoney(Currency Currency) : IFunds
{
    decimal IFunds.Amount => 0M;
}