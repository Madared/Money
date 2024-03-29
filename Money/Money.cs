namespace Money;

public record Money(IPositiveDecimal CashAmount, Currency.Currency Currency) : IFunds
{
    decimal IFunds.Amount => CashAmount.Amount;
}