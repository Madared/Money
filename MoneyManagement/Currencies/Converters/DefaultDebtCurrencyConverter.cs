using MoneyManagement.Decimals;
using MoneyManagement.Decimals.Math;
using MoneyManagement.Currencies.RateService;
using MoneyManagement.Funds;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions.Async;

namespace MoneyManagement.Currencies.Converters;

public sealed class DefaultDebtCurrencyConverter : IDebtCurrencyConverter {
    private readonly IRateService _rateService;
    private readonly IFundsFactory _fundsFactory;

    public DefaultDebtCurrencyConverter(IRateService rateService) {
        _rateService = rateService;
    }

    public Task<Result<Debt>> Convert(Debt toConvert, Currency convertTo) => _rateService
        .GetRate(toConvert.Currency, convertTo)
        .MapAsync(toConvert.DebtAmount.TimesPositive)
        .MapAsync(negativeAmount => new NegativeDecimal(negativeAmount))
        .MapAsync(converted => _fundsFactory.Debt(converted, convertTo));
}