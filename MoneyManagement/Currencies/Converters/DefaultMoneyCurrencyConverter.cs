using MoneyManagement.Decimals;
using MoneyManagement.Decimals.Math;
using MoneyManagement.Currencies.RateService;
using MoneyManagement.Funds;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions.Async;

namespace MoneyManagement.Currencies.Converters;

/// <summary>
/// Default implementation of money currency converter
/// </summary>
public sealed class DefaultMoneyCurrencyConverter : IMoneyCurrencyConverter
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
        .MapAsync(positiveAmount => new PositiveDecimal(positiveAmount))
        .MapAsync(cashAmount => new Funds.Money(cashAmount, convertTo));
}