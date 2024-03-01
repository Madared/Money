using Results;

namespace Money.Currency.Converters;

public interface IMoneyCurrencyConverter
{
    Result<Money> Convert(Money toConvert, Currency convertTo);
}