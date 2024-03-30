using Money.Currency.RateService;
using Results;

namespace Money.Currency.Converters;

public class DefaultDebtCurrencyConverter : IFundsCurrencyConverter<Debt> {
    private readonly IRateService _rateService;

    public DefaultDebtCurrencyConverter(IRateService rateService) {
        _rateService = rateService;
    }

    public Task<Result<Debt>> Convert(Debt toConvert, Currency convertTo) => _rateService
        .GetRate(toConvert.Currency, convertTo)
        .MapAsync(rate => toConvert.DebtAmount.TimesPositive(rate))
        .MapAsync(converted => new Debt(converted, convertTo));
}