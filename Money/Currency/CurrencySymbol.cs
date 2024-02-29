using System.Diagnostics;

namespace Money;

public record CurrencySymbol(string Symbol, string AbbreviationCode, CurrencySymbolPosition Position, bool Spaced)
{
    public string AddSymbol(string value) => Position switch
    {
        CurrencySymbolPosition.prefix => Symbol + (Spaced ? " " : "") + value,
        CurrencySymbolPosition.postfix => value + (Spaced ? " " : "") + Symbol,
        CurrencySymbolPosition.separator => value.Replace(".", Symbol),
        _ => throw new UnreachableException()
    };
}