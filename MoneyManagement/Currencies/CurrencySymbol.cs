namespace MoneyManagement.Currencies;

public abstract record CurrencySymbol(string Symbol, string AbbreviationCode);

public sealed record BasicCurrencySymbol(string Symbol, string AbbreviationCode) : CurrencySymbol(Symbol, AbbreviationCode);