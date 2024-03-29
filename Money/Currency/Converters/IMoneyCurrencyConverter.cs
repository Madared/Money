using Results;

namespace Money.Currency.Converters;

public interface IMoneyCurrencyConverter : IFundsCurrencyConverter<Money>
{
    Task<Result<Money>> Convert(Money toConvert, Currency convertTo);
}