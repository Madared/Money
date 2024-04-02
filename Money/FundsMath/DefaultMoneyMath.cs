using Money.Currencies.Converters;
using Money.Decimals;
using Results;

namespace Money.FundsMath;

public class DefaultMoneyMath {
    private readonly IMoneyCurrencyConverter _converter;

    public DefaultMoneyMath(IMoneyCurrencyConverter converter) {
        _converter = converter;
    }

    public Task<Result<Money>> Plus(Money first, Money second) => Apply(first, second, SameCurrencyPlus);
    public Task<Result<Money>> Minus(Money first, Money second) => Apply(first, second, SameCurrencyMinus);

    private delegate Result<Money> MoneyMathOperation(Money first, Money second);

    private async Task<Result<Money>> Apply(Money first, Money second, MoneyMathOperation operation) => first.Currency == second.Currency
        ? operation(first, second)
        : await _converter.Convert(second, first.Currency)
            .MapAsync(converted => operation(first, converted));

    private Result<Money> SameCurrencyPlus(Money first, Money second) => first.CashAmount
        .Plus(second.CashAmount)
        .Map(total => new Money(total, first.Currency));

    private Result<Money> SameCurrencyMinus(Money first, Money second) => (first.CashAmount.Amount - second.CashAmount.Amount)
        .PipeNonNull(PositiveDecimal.Create)
        .Map(total => new Money(total, first.Currency));
}