using Money.Decimals;
using Money.Decimals.Math;
using Results;

namespace Money.FundsMath;

public static class MoneyMathExtensions {
    public static Result<Money> Times(this Money money, IPositiveDecimal multiplier) => money.CashAmount
        .Times(multiplier)
        .Map(total => money with { CashAmount = total });

    public static Result<Money> Divide(this Money money, IPositiveDecimal divider) => money.CashAmount
        .DivideBy(divider)
        .AsPositive()
        .Map(total => money with { CashAmount = total });
}