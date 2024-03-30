using Results;

namespace Money.DecimalMath;

public static class DebtMathExtensions {
    public static Debt Times(this Debt debt, IPositiveDecimal multiplier) => debt.DebtAmount
        .TimesPositive(multiplier)
        .PipeNonNull(total => new Debt(total, debt.Currency));

    public static Result<Debt> DivideBy(this Debt debt, IPositiveDecimal dividend) => debt.DebtAmount
        .DividePositive(dividend)
        .Map(total => new Debt(total, debt.Currency));
}