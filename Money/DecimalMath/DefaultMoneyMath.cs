using Microsoft.VisualBasic;
using Money.Currency.Converters;
using Results;

namespace Money.DecimalMath;

public class DefaultMoneyMath {
    private readonly IMoneyCurrencyConverter _converter;

    public DefaultMoneyMath(IMoneyCurrencyConverter converter) {
        _converter = converter;
    }

    public async Task<Result<Money>> Plus(Money first, Money second) => first.Currency == second.Currency
        ? SameCurrencyPlus(first, second)
        : await _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyPlus(first, converted));

    public async Task<Result<Money>> Times(Money first, Money second) => first.Currency == second.Currency
        ? SameCurrencyTimes(first, second)
        : await _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyTimes(first, converted));

    public async Task<Result<Money>> Divide(Money first, Money second) => first.Currency == second.Currency
        ? SameCurrencyDivide(first, second)
        : await _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyDivide(first, converted));

    public async Task<Result<Money>> Minus(Money first, Money second) => first.Currency == second.Currency
        ? SameCurrencyMinus(first, second)
        : await _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyMinus(first, converted));

    private Result<Money> SameCurrencyPlus(Money first, Money second) => first.CashAmount
        .Plus(second.CashAmount)
        .Map(total => new Money(total, first.Currency));

    private Result<Money> SameCurrencyTimes(Money first, Money second) => first.CashAmount
        .Times(second.CashAmount)
        .Map(total => new Money(total, first.Currency));

    private Result<Money> SameCurrencyDivide(Money first, Money second) => first.CashAmount
        .DivideBy(second.CashAmount)
        .Map(total => new Money(total, first.Currency));

    private Result<Money> SameCurrencyMinus(Money first, Money second) => (first.CashAmount.Amount - second.CashAmount.Amount)
        .PipeNonNull(PositiveDecimal.Create)
        .Map(total => new Money(total, first.Currency));
}