namespace Money;

public record NoMoney(Currency.Currency Currency) : IFunds
{
    decimal IFunds.Amount => 0M;
}