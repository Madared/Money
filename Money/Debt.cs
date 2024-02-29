namespace Money;

public record Debt(INegativeDecimal DebtAmount, Currency.Currency Currency) : IFunds
{
    decimal IFunds.Amount => DebtAmount.Amount;
}