using Results;

namespace Money;

public class SimpleMoneyCurrencyConverter : IMoneyCurrencyConverter
{
    private readonly IRateService _rateService;

    public SimpleMoneyCurrencyConverter(IRateService service)
    {
        _rateService = service;
    }

    public Result<Money> Convert(Money toConvert, Currency convertTo) => Task.Run(() =>_rateService
        .GetRate(toConvert.Currency, convertTo)).Result
        .Map(rate => toConvert.CashAmount.Times(rate))
        .Map(cashAmount => new Money(cashAmount, convertTo));
}