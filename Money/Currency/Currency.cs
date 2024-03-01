using System.Globalization;
using Results;

namespace Money.Currency;

public record Currency(CurrencyName CurrencyName, CurrencyRates Rates, CurrencySymbol Symbol, CurrencySeparators Separators)
{
    string Format(decimal value) => Math.Round(value, Rates.DisplayPrecision)
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