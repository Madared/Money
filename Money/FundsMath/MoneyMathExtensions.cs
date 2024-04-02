using Money.Decimals;
using Results;

namespace Money.FundsMath;

public static class MoneyMathExtensions {
    public static Result<Money> Times(this Money money, IPositiveDecimal multiplier) => money.CashAmount
        .Times(multiplier)
        .Map(total => new Money(total, money.Currency));

    public static Result<Money> Divide(this Money money, IPositiveDecimal divider) => money.CashAmount
        .DivideBy(divider)
        .Map(total => new Money(total, money.Currency));
}