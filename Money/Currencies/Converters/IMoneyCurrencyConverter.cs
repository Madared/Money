using Results;

namespace Money.Currencies.Converters;

public interface IMoneyCurrencyConverter : IFundsCurrencyConverter<Money>
{
    Task<Result<Money>> Convert(Money toConvert, Currency convertTo);
}