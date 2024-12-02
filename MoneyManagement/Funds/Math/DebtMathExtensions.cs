using MoneyManagement.Decimals.Math;
using MoneyManagement.Decimals;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds.Math;

public static class DebtMathExtensions {
    public static Result<Debt> Times(this Debt debt, IPositiveDecimal multiplier) => debt.DebtAmount
        .TimesPositive(multiplier)
        .Map(negativeAmount => new NegativeDecimal(negativeAmount))
        .Map(total => new Debt(total, debt.Currency));

    public static Result<INonPositiveFunds> DivideBy(this Debt debt, IPositiveDecimal dividend) => debt.DebtAmount
        .DividePositive(dividend)
        .Map(total => FundsFactory.CreateNonPositive(total, debt.Currency));
}