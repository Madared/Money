using MoneyManagement.Decimals;
using MoneyManagement.Decimals.Math;
using MoneyManagement.Currencies.RateService;
using MoneyManagement.Funds;
using Results;

namespace MoneyManagement.Currencies.Converters;

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