using Results;

namespace Money;

public interface IMoneyCurrencyConverter
{
    Result<Money> Convert(Money toConvert, Currency convertTo);
}