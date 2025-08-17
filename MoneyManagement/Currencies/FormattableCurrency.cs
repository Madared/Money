using System.Globalization;
using ResultAndOption;
using ResultAndOption.Results;

namespace MoneyManagement.Currencies;

public abstract class FormattableCurrency : Currency
{
    public abstract FormattableCurrencySymbol FormattableSymbol { get; }
    public abstract CurrencyPrecisions Precisions { get; }
    public abstract CurrencySeparators Separators { get; }
}