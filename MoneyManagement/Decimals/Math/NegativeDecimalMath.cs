using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Decimals.Math;

public static class NegativeDecimalMath {
    public static Result<NegativeDecimal> Plus(this NegativeDecimal first, NegativeDecimal second) {
        try {
            decimal final = first.Amount + second.Amount;
            return NegativeDecimal.Create(final);
        }
        catch (OverflowException ex) {
            return Result<NegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static Result<NegativeDecimal> TimesPositive(this NegativeDecimal first, PositiveDecimal second) {
        try {
            decimal final = first.Amount * second.Amount;
            return NegativeDecimal.Create(final);
        }
        catch (OverflowException ex) {
            return Result<NegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static NegativeDecimal TimesPositiveOrThrow(this NegativeDecimal first, PositiveDecimal second) {
        decimal total = first.Amount * second.Amount;
        return NegativeDecimal.Create(total).Data;
    }

    public static Result<PositiveDecimal> Times(this NegativeDecimal first, NegativeDecimal second) {
        try {
            decimal final = first.Amount * second.Amount;
            return PositiveDecimal.Create(final);
        }
        catch (OverflowException ex) {
            return Result<PositiveDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static PositiveDecimal TimesOrThrow(this NegativeDecimal first, NegativeDecimal second) {
        decimal total = first.Amount * second.Amount;
        return PositiveDecimal.Create(total).Data;
    }

    public static Result<INonNegativeDecimal> Divide(this NegativeDecimal first, NegativeDecimal second) {
        try {
            decimal final = first.Amount / second.Amount;
            return DecimalFactory.CreateNonNegative(final);
        }
        catch (OverflowException ex) {
            return Result<INonNegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static INonNegativeDecimal DivideOrThrow(this NegativeDecimal first, NegativeDecimal second) => DecimalFactory
        .CreateNonNegative(first.Amount / second.Amount)
        .Data;

    public static Result<INonPositiveDecimal> DividePositive(this NegativeDecimal first, PositiveDecimal second) {
        try {
            decimal final = first.Amount / second.Amount;
            return DecimalFactory.CreateNonPositive(final);
        }
        catch (OverflowException ex) {
            return Result<INonPositiveDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static INonPositiveDecimal DividePositiveOrThrow(this NegativeDecimal first, PositiveDecimal second) {
        decimal final = first.Amount / second.Amount;
        return DecimalFactory.CreateNonPositive(final).Data;
    }
}