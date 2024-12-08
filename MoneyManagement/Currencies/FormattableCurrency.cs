using System.Globalization;
using ResultAndOption;
using ResultAndOption.Results;

namespace MoneyManagement.Currencies;

public sealed class FormattableCurrency(
    CurrencyName name,
    FormattableCurrencySymbol symbol,
    CurrencyPrecisions precisions,
    CurrencySeparators separators)
    : Currency
{
    public override CurrencyName Name { get; } = name;
    public override FormattableCurrencySymbol Symbol { get; } = symbol;
    public CurrencyPrecisions Precisions { get; } = precisions;
    public CurrencySeparators Separators { get; } = separators;

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