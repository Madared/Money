using MoneyManagement.Decimals.Math;
using MoneyManagement.Decimals;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds.Math;

public static class MoneyMathExtensions {
    public static Result<Money> Times(this Money money, IPositiveDecimal multiplier) => money.CashAmount
        .Times(multiplier)
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => money with { CashAmount = total });

    public static Result<Money> Divide(this Money money, IPositiveDecimal divider) => money.CashAmount
        .DivideBy(divider)
        .Map(value => value.AsPositive())
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => money with { CashAmount = total });
}