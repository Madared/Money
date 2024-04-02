using Money.Currencies.RateService;
using Money.Decimals;
using Money.Decimals.Math;
using Money.Funds;
using Results;

namespace Money.Currencies.Converters;

public class DefaultDebtCurrencyConverter : IDebtCurrencyConverter {
    private readonly IRateService _rateService;

    public DefaultDebtCurrencyConverter(IRateService rateService) {
        _rateService = rateService;
    }

    public Task<Result<Debt>> Convert(Debt toConvert, Currency convertTo) => _rateService
        .GetRate(toConvert.Currency, convertTo)
        .MapAsync(rate => toConvert.DebtAmount.TimesPositive(rate))
        .MapAsync(converted => new Debt(converted, convertTo));
}