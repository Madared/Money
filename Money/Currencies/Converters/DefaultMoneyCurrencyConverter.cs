using Money.Currencies.RateService;
using Money.Decimals;
using Money.Decimals.Math;
using Results;

namespace Money.Currencies.Converters;

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
    public Task<Result<Funds.Money>> Convert(Funds.Money toConvert, Currency convertTo) => Task.Run(() =>_rateService
        .GetRate(toConvert.Currency, convertTo))
        .MapAsync(toConvert.CashAmount.Times)
        .MapAsync(cashAmount => new Funds.Money(cashAmount, convertTo));
}