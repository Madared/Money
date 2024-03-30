using Money.Currency.Converters;
using Results;

namespace Money.DecimalMath;

public class DefaultMoneyMath : IMoneyMath {
    private readonly IMoneyCurrencyConverter _converter;

    public DefaultMoneyMath(IMoneyCurrencyConverter converter) {
        _converter = converter;
    }

    public Task<Result<Money>> Plus(Money first, Money second) {
        if (first.Currency == second.Currency) {
            return Task.FromResult(
                Result<Money>.Ok(SameCurrencyPlus(first, second))
            );
        }

        return _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyPlus(first, converted));
    }

    public Task<Result<Money>> Times(Money first, Money second) {
        if (first.Currency == second.Currency) {
            return Task.FromResult(
                Result<Money>.Ok(SameCurrencyTimes(first, second))
            );
        }

        return _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyTimes(first, converted));
    }

    public Task<Result<Money>> Divide(Money first, Money second) {
        if (first.Currency == second.Currency) {
            return Task.FromResult(
                SameCurrencyDivide(first, second)
            );
        }

        return _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyDivide(first, converted));
    }

    public Task<Result<Money>> Minus(Money first, Money second) {
        if (first.Currency == second.Currency) {
            return Task.FromResult(
                SameCurrencyMinus(first, second)
            );
        }

        return _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyMinus(first, converted));
    }

    private Money SameCurrencyPlus(Money first, Money second) => first.CashAmount
        .Plus(second.CashAmount)
        .PipeNonNull(total => new Money(total, first.Currency));

    private Money SameCurrencyTimes(Money first, Money second) => first.CashAmount
        .Times(second.CashAmount)
        .PipeNonNull(total => new Money(total, first.Currency));

    private Result<Money> SameCurrencyDivide(Money first, Money second) => first.CashAmount
        .DivideBy(second.CashAmount)
        .Map(total => new Money(total, first.Currency));

    private Result<Money> SameCurrencyMinus(Money first, Money second) => (first.CashAmount.Amount - second.CashAmount.Amount)
        .PipeNonNull(PositiveDecimal.Create)
        .Map(total => new Money(total, first.Currency));
}

public static class MoneyMathExtensions {
    public static Money Times(this Money money, IPositiveDecimal multiplier) => money.CashAmount
        .Times(multiplier)
        .PipeNonNull(total => new Money(total, money.Currency));

    public static Result<Money> Divide(this Money money, IPositiveDecimal divider) => money.CashAmount
        .DivideBy(divider)
        .Map(total => new Money(total, money.Currency));
}