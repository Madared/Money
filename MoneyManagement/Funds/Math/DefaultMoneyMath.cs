using MoneyManagement.Decimals.Math;
using MoneyManagement.Currencies.Converters;
using MoneyManagement.Decimals;
using ResultAndOption;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;
using ResultAndOption.Results.GenericResultExtensions.Async;

namespace MoneyManagement.Funds.Math;

public sealed class DefaultMoneyMath {
    private readonly IMoneyCurrencyConverter _converter;
    private readonly IFundsFactory _factory;
    public DefaultMoneyMath(IMoneyCurrencyConverter converter) {
        _converter = converter;
    }

    public Task<Result<Money>> Plus(Money first, Money second) => Apply(first, second, SameCurrencyPlus);
    public Task<Result<Money>> Minus(Money first, Money second) => Apply(first, second, SameCurrencyMinus);

    public Result<Money> Times(Money money, IPositiveDecimal multiplier) => money.CashAmount
        .Times(multiplier)
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => _factory.Money(total, money.Currency));

    public Result<Money> Divide(Money money, IPositiveDecimal divider) => money.CashAmount
        .DivideBy(divider)
        .Map(value => value.AsPositive())
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => _factory.Money(total, money.Currency));
    private delegate Result<Money> MoneyMathOperation(Money first, Money second);

    private async Task<Result<Money>> Apply(Money first, Money second, MoneyMathOperation operation) => first.Currency == second.Currency
        ? operation(first, second)
        : await _converter.Convert(second, first.Currency)
            .MapAsync(converted => operation(first, converted));

    private Result<Money> SameCurrencyPlus(Money first, Money second) => first.CashAmount
        .Plus(second.CashAmount)
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => _factory.Money(total, first.Currency));

    private Result<Money> SameCurrencyMinus(Money first, Money second) => (first.CashAmount.Amount - second.CashAmount.Amount)
        .Pipe(PositiveDecimal.Create)
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => _factory.Money(total, first.Currency));
}