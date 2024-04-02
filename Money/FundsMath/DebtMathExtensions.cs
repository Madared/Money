using Money.Decimals;
using Money.Decimals.Math;
using Results;

namespace Money.FundsMath;

public static class DebtMathExtensions {
    public static Result<Debt> Times(this Debt debt, IPositiveDecimal multiplier) => debt.DebtAmount
        .TimesPositive(multiplier)
        .Map(total => new Debt(total, debt.Currency));

    public static Result<Debt> DivideBy(this Debt debt, IPositiveDecimal dividend) => debt.DebtAmount
        .DividePositive(dividend)
        .Map(total => new Debt(total, debt.Currency));
}