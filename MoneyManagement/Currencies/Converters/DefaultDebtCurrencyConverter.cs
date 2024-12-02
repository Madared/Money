using MoneyManagement.Decimals;
using MoneyManagement.Decimals.Math;
using MoneyManagement.Currencies.RateService;
using MoneyManagement.Funds;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions.Async;

namespace MoneyManagement.Currencies.Converters;

public sealed class DefaultDebtCurrencyConverter : IDebtCurrencyConverter {
    private readonly IRateService _rateService;

    public DefaultDebtCurrencyConverter(IRateService rateService) {
        _rateService = rateService;
    }

    public Task<Result<Debt>> Convert(Debt toConvert, Currency convertTo) => _rateService
        .GetRate(toConvert.Currency, convertTo)
        .MapAsync(rate => toConvert.DebtAmount.TimesPositive(rate))
        .MapAsync(negativeAmount => new NegativeDecimal(negativeAmount))
        .MapAsync(converted => new Debt(converted, convertTo));
}