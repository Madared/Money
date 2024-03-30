using Results;

namespace Money;

public static class NegativeDecimalMath {

    public static INegativeDecimal Plus(this INegativeDecimal first, INegativeDecimal second) {
        decimal final = first.Amount + second.Amount;
        return NegativeDecimal.Create(final).Data;
    }

    public static INegativeDecimal TimesPositive(this INegativeDecimal first, IPositiveDecimal second) {
        decimal final = first.Amount * second.Amount;
        return NegativeDecimal.Create(final).Data;
    }

    public static IPositiveDecimal Times(this INegativeDecimal first, INegativeDecimal second) {
        decimal final = first.Amount * second.Amount;
        return PositiveDecimal.Create(final).Data;
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