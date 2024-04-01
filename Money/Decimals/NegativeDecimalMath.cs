using Results;

namespace Money.Decimals;

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
            return NegativeDecimal.Create(final).Map(negative=> negative as INegativeDecimal);
        }
        catch (OverflowException ex) {
            return Result<INegativeDecimal>.Fail(new ExceptionWrapper(ex));
        }
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

    public static Result<IPositiveDecimal> Divide(this INegativeDecimal first, INegativeDecimal second) {
        try {
            decimal final = first.Amount / second.Amount;
            return PositiveDecimal.Create(final).Map(positive => positive as IPositiveDecimal);
        }
        catch (Exception e) {
            return Result<IPositiveDecimal>.Fail(new ExceptionWrapper(e));
        }
    }

    public static Result<INegativeDecimal> DividePositive(this INegativeDecimal first, IPositiveDecimal second) {
        try {
            decimal final = first.Amount / second.Amount;
            return NegativeDecimal.Create(final).Map(negative => negative as INegativeDecimal);
        }
        catch (Exception e) {
            return Result<INegativeDecimal>.Fail(new ExceptionWrapper(e));
        }
    }
    
}