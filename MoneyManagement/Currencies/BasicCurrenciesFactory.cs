namespace MoneyManagement.Currencies;

public static class BasicCurrenciesFactory
{
    public static Currency Dollar()
    {
        CurrencySymbol symbol = new BasicCurrencySymbol("$", "USD");
        CurrencyName name = CurrencyName.Create("Dollar").Data;
        return new BasicCurrency(name, symbol);
    }

    public static Currency Euro()
    {
        CurrencySymbol symbol = new BasicCurrencySymbol("€", "EUR");
        CurrencyName name = CurrencyName.Create("Euro").Data;
        return new BasicCurrency(name, symbol);
    }

    public static Currency EscudoCv()
    {
        CurrencySymbol symbol = new BasicCurrencySymbol("$", "CVE");
        CurrencyName name = CurrencyName.Create("Escudo").Data;
        return new BasicCurrency(name, symbol);
    }
}