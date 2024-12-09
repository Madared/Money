namespace MoneyManagement.Currencies;

public abstract class Currency
{
    public abstract CurrencyName Name { get; }
    public abstract CurrencySymbol Symbol { get; }
}

public sealed class BasicCurrency(CurrencyName name, CurrencySymbol symbol) : Currency
{
    public override CurrencyName Name { get; } = name;
    public override CurrencySymbol Symbol { get; } = symbol;
}