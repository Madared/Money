using System.Diagnostics;

namespace Money.Currencies;

public record CurrencySymbol(string Symbol, string AbbreviationCode, CurrencySymbolPosition Position, bool Spaced)
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
        CurrencySymbolPosition.prefix => Symbol + (Spaced ? " " : "") + value,
        CurrencySymbolPosition.postfix => value + (Spaced ? " " : "") + Symbol,
        CurrencySymbolPosition.separator => value.Replace(".", Symbol),
        _ => throw new UnreachableException()
    };
}