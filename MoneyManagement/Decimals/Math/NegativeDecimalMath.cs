using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Decimals.Math;

public static class NegativeDecimalMath {
    public static Result<INegativeDecimal> Plus(this INegativeDecimal first, INegativeDecimal second) {
        try {
            decimal final = first.Amount + second.Amount;
            return NegativeDecimal.Create(final).Map(negative => negative as INegativeDecimal);
        }
        catch (OverflowException ex) {
            return Result<INegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static Result<INegativeDecimal> TimesPositive(this INegativeDecimal first, IPositiveDecimal second) {
        try {
            decimal final = first.Amount * second.Amount;
            return NegativeDecimal.Create(final).Map(negative => negative as INegativeDecimal);
        }
        catch (OverflowException ex) {
            return Result<INegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static INegativeDecimal TimesPositiveOrThrow(this INegativeDecimal first, IPositiveDecimal second) {
        decimal total = first.Amount * second.Amount;
        return NegativeDecimal.Create(total).Data;
    }

    public static Result<IPositiveDecimal> Times(this INegativeDecimal first, INegativeDecimal second) {
        try {
            decimal final = first.Amount * second.Amount;
            return PositiveDecimal.Create(final).Map(positive => positive as IPositiveDecimal);
        }
        catch (OverflowException ex) {
            return Result<IPositiveDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static IPositiveDecimal TimesOrThrow(this INegativeDecimal first, INegativeDecimal second) {
        decimal total = first.Amount * second.Amount;
        return PositiveDecimal.Create(total).Data;
    }

    public static Result<INonNegativeDecimal> Divide(this INegativeDecimal first, INegativeDecimal second) {
        try {
            decimal final = first.Amount / second.Amount;
            return DecimalFactory.CreateNonNegative(final);
        }
        catch (OverflowException ex) {
            return Result<INonNegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static INonNegativeDecimal DivideOrThrow(this INegativeDecimal first, INegativeDecimal second) => DecimalFactory
        .CreateNonNegative(first.Amount / second.Amount)
        .Data;

    public static Result<INonPositiveDecimal> DividePositive(this INegativeDecimal first, IPositiveDecimal second) {
        try {
            decimal final = first.Amount / second.Amount;
            return DecimalFactory.CreateNonPositive(final);
        }
        catch (OverflowException ex) {
            return Result<INonPositiveDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static INonPositiveDecimal DividePositiveOrThrow(this INegativeDecimal first, IPositiveDecimal second) {
        decimal final = first.Amount / second.Amount;
        return DecimalFactory.CreateNonPositive(final).Data;
    }
}