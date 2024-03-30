using Results;

namespace Money;

public static class PositiveDecimalMath
{
    /// <summary>
    /// Multiplies two positive decimal values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    public static IPositiveDecimal Times(this IPositiveDecimal positiveDecimal, IPositiveDecimal multiplier) =>
        PositiveDecimal.Create(positiveDecimal.Amount * multiplier.Amount).Data;

    /// <summary>
    /// Divides two positive decimal values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    public static Result<IPositiveDecimal> DivideBy(this IPositiveDecimal positiveDecimal, IPositiveDecimal dividend) => PositiveDecimal
        .Create(positiveDecimal.Amount / dividend.Amount)
        .Map(positive => positive as IPositiveDecimal);

    /// <summary>
    /// Adds two positive values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    public static IPositiveDecimal Plus(this IPositiveDecimal positiveDecimal, IPositiveDecimal additive) =>
        PositiveDecimal.Create(positiveDecimal.Amount + additive.Amount).Data;
}