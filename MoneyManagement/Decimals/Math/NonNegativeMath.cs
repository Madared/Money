using Results;

namespace MoneyManagement.Decimals.Math;

public static class NonNegativeMath {
    public static Result<INonNegativeDecimal> Plus(this INonNegativeDecimal first, INonNegativeDecimal second) {
        try {
            decimal total = first.Amount + second.Amount;
            return DecimalFactory.CreateNonNegative(total);
        }
        catch (OverflowException ex) {
            return Result<INonNegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static INonNegativeDecimal PlusOrThrow(this INonNegativeDecimal first, INonNegativeDecimal second) {
        decimal total = first.Amount + second.Amount;
        return DecimalFactory.CreateNonNegative(total).Data;
    }

    public static Result<INonNegativeDecimal> Times(this INonNegativeDecimal first, INonNegativeDecimal second) {
        try {
            decimal total = first.Amount * second.Amount;
            return DecimalFactory.CreateNonNegative(total);
        }
        catch (OverflowException ex) {
            return Result<INonNegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    public static INonNegativeDecimal TimesOrThrow(this INonNegativeDecimal first, INonNegativeDecimal second) {
        decimal total = first.Amount * second.Amount;
        return DecimalFactory.CreateNonNegative(total).Data;
    }

    public static Result<INonNegativeDecimal> DivideBy(this INonNegativeDecimal first, INonNegativeDecimal second) {
        try {
            decimal total = first.Amount / second.Amount;
            return DecimalFactory.CreateNonNegative(total);
        }
        catch (OverflowException ex) {
            return Result<INonNegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
        catch (DivideByZeroException ex) {
            return Result<INonNegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }
}