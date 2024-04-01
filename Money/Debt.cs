using Money.Currencies;
using Money.Decimals;

namespace Money;

public record Debt(INegativeDecimal DebtAmount, Currency Currency) : INonPositiveFunds
{
    decimal IFunds.Amount => DebtAmount.Amount;
}