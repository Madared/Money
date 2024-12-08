using System.Globalization;
using ResultAndOption;
using ResultAndOption.Results;

namespace MoneyManagement.Currencies;

public sealed class FormattableCurrency : Currency
{
    public override CurrencyName Name { get; }
    public override FormattableCurrencySymbol Symbol { get; }
    public CurrencyPrecisions Precisions { get; }
    public CurrencySeparators Separators { get; }

    public FormattableCurrency(
        CurrencyName name,
        FormattableCurrencySymbol symbol,
        CurrencyPrecisions precisions,
        CurrencySeparators separators)
    {
        Name = name;
        Symbol = symbol;
        Precisions = precisions;
        Separators = separators;
    }

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
}