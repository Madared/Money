using Money.Currency.Converters;
using Results;

namespace Money.DecimalMath;

public interface IDebtMath {
    Task<Result<Debt>> Plus(Debt first, Debt second);
}

public class DefaultDebtMath : IDebtMath {
    private readonly IDebtCurrencyConverter _converter;
    
    public DefaultDebtMath(IDebtCurrencyConverter converter) {
        _converter = converter;
    }

    public async Task<Result<Debt>> Plus(Debt first, Debt second) {
        if (first.Currency == second.Currency) {
            return SameCurrencyPlus(first, second).ToResult(new UnknownError());
        }

        return await _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyPlus(first, converted));
    }

    private Debt SameCurrencyPlus(Debt first, Debt second) => first.DebtAmount
        .Plus(second.DebtAmount)
        .PipeNonNull(total => new Debt(total, first.Currency));
}

public static class DebtMathExtensions {
    public static Debt Times(this Debt debt, IPositiveDecimal multiplier) => debt.DebtAmount
        .TimesPositive(multiplier)
        .PipeNonNull(total => new Debt(total, debt.Currency));

    public static Result<Debt> DivideBy(this Debt debt, IPositiveDecimal dividend) => debt.DebtAmount
        .DividePositive(dividend)
        .Map(total => new Debt(total, debt.Currency));
}