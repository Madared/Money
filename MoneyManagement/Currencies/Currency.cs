using System.Globalization;
using Results;

namespace MoneyManagement.Currencies;

public record Currency(CurrencyName CurrencyName, CurrencyRates Rates, CurrencySymbol Symbol, CurrencySeparators Separators)
{
    /// <summary>
    /// Formats the currency value according to the specific internals provided such as symbols, separators, and precisions
    /// </summary>
    /// <param name="value">value to format</param>
    /// <returns></returns>
    public string Format(decimal value) => Math.Round(value, Rates.DisplayPrecision)
        .ToString(CultureInfo.InvariantCulture)
        .PipeNonNull(Symbol.AddSymbol)
        .PipeNonNull(strValue => Separators.AddThousandSeparator(strValue, Rates.DisplayPrecision))
        .PipeNonNull(strValue => Separators.ReplaceDecimalSeparator(strValue, Rates.DisplayPrecision));

    public static Currency Dollar()
    {
        CurrencyName currencyName = CurrencyName.Create("dollar").Data;
        CurrencySeparators separators = new(",", ".");
        CurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.prefix, true);
        CurrencyRates rates = new(ConversionRate.One(), DecimalPrecisionValue.Two(), DecimalPrecisionValue.Two());
        Currency dollar = new(currencyName, rates, symbol, separators);
        return dollar;
    }
}