using System.Diagnostics;

namespace MoneyManagement.Currencies;

public sealed record FormattableCurrencySymbol(
    string Symbol,
    string AbbreviationCode,
    CurrencySymbolPosition Position,
    bool Spaced) : CurrencySymbol(Symbol, AbbreviationCode)
{
    /// <summary>
    /// Adds the currency symbol to a string representation of the decimal value
    /// when the decimal separator has not yet been replaced
    /// </summary>
    /// <param name="value">string representation of the decimal value</param>
    /// <returns>The string representation of the decimal vlaue with the currency symbol</returns>
    /// <exception cref="UnreachableException"></exception>
    public string AddSymbol(string value) => Position switch
    {
        CurrencySymbolPosition.Prefix => Symbol + (Spaced ? " " : "") + value,
        CurrencySymbolPosition.Postfix => value + (Spaced ? " " : "") + Symbol,
        CurrencySymbolPosition.Separator => value.Replace(".", Symbol),
        _ => throw new UnreachableException()
    };
}