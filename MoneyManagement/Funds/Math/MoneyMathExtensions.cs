using MoneyManagement.Decimals.Math;
using MoneyManagement.Decimals;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds.Math;

public static class MoneyMathExtensions {
    public static Result<Money> Times(this Money money, IPositiveDecimal multiplier, IFundsFactory factory) => money.CashAmount
        .Times(multiplier)
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => factory.Money(total, money.Currency));

    public static Result<Money> Divide(this Money money, IPositiveDecimal divider, IFundsFactory factory) => money.CashAmount
        .DivideBy(divider)
        .Map(value => value.AsPositive())
        .Map(positiveAmount => new PositiveDecimal(positiveAmount))
        .Map(total => factory.Money(total, money.Currency));
}