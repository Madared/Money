using Results;

namespace Money.Currency.Converters;

public interface IMoneyCurrencyConverter
{
    Result<Money> Convert(Money toConvert, global::Money.Currency.Currency convertTo);
}