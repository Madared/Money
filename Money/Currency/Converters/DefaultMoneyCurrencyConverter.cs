using Money.Currency.RateService;
using Results;

namespace Money.Currency.Converters;

/// <summary>
/// Default implementation of money currency converter
/// </summary>
public class DefaultMoneyCurrencyConverter : IMoneyCurrencyConverter
{
    private readonly IRateService _rateService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service">Rate service used for conversion</param>
    public DefaultMoneyCurrencyConverter(IRateService service)
    {
        _rateService = service;
    }

    /// <summary>
    /// Converts any Money amount to specified currency
    /// </summary>
    /// <param name="toConvert">Money to convert</param>
    /// <param name="convertTo">Currency to convert to</param>
    /// <returns></returns>
    public Task<Result<Money>> Convert(Money toConvert, Currency convertTo) => Task.Run(() =>_rateService
        .GetRate(toConvert.Currency, convertTo))
        .MapAsync(toConvert.CashAmount.Times)
        .MapAsync(cashAmount => new Money(cashAmount, convertTo));
}