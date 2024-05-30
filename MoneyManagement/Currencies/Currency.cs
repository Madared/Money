using System.Globalization;
using Results;

namespace MoneyManagement.Currencies;

public sealed record Currency(
    CurrencyName CurrencyName,
    CurrencyPrecisions Precisions,
    CurrencySymbol Symbol,
    CurrencySeparators Separators)
{
    /// <summary>
    /// Formats the currency value according to the specific internals provided such as symbols, separators, and precisions
    /// </summary>
    /// <param name="value">value to format</param>
    /// <returns></returns>
    public string Format(decimal value) => Math.Round(value, Precisions.DisplayPrecision)
        .ToString(CultureInfo.InvariantCulture)
        .Pipe(Symbol.AddSymbol)
        .Pipe(strValue => Separators.AddThousandSeparator(strValue, Precisions.DisplayPrecision))
        .Pipe(strValue => Separators.ReplaceDecimalSeparator(strValue, Precisions.DisplayPrecision));

    public static Currency Dollar()
    {
        CurrencyName currencyName = CurrencyName.Create("dollar").Data;
        CurrencySeparators separators = new(",", ".");
        CurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.prefix, true);
        CurrencyPrecisions precisions = new(DecimalPrecisionValue.Two(), DecimalPrecisionValue.Two());
        Currency dollar = new(currencyName, precisions, symbol, separators);
        return dollar;
    }
}