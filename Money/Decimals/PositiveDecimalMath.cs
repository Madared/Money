using Results;

namespace Money;

/// <summary>
/// Extension methods to do math on positive decimals
/// </summary>
public static class PositiveDecimalMath
{
    /// <summary>
    /// Multiplies two positive decimal values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    public static Result<IPositiveDecimal> Times(this IPositiveDecimal positiveDecimal, IPositiveDecimal multiplier) {
        try {
            return PositiveDecimal
                .Create(positiveDecimal.Amount * multiplier.Amount)
                .Map(positive => positive as IPositiveDecimal);
        }
        catch (OverflowException ex) {
            return Result<IPositiveDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    /// <summary>
    /// Divides two positive decimal values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    public static Result<IPositiveDecimal> DivideBy(this IPositiveDecimal positiveDecimal, IPositiveDecimal dividend) {
        try {
            return PositiveDecimal
                .Create(positiveDecimal.Amount / dividend.Amount)
                .Map(positive => positive as IPositiveDecimal);
        }
        catch (OverflowException ex) {
            return Result<IPositiveDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }

    /// <summary>
    /// Adds two positive values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    public static Result<IPositiveDecimal> Plus(this IPositiveDecimal positiveDecimal, IPositiveDecimal additive) {
        try {
            return PositiveDecimal
                .Create(positiveDecimal.Amount + additive.Amount)
                .Map(positive => positive as IPositiveDecimal);
        }
        catch (OverflowException ex) {
            return Result<IPositiveDecimal>.Fail(new ExceptionWrapper(ex));
        }
    }
}