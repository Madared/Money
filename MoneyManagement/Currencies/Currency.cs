namespace MoneyManagement.Currencies;

public abstract class Currency
{
    public abstract CurrencyName Name { get; }
    public abstract CurrencySymbol Symbol { get; }
}