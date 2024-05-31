using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Decimals.Math;

/// <summary>
/// Extension methods to do math on positive decimals
/// </summary>
public static class PositiveDecimalMath {
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
    /// 
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <param name="multiplier"></param>
    /// <exception cref="OverflowException"></exception>
    /// <returns></returns>
    public static IPositiveDecimal TimesOrThrow(this IPositiveDecimal positiveDecimal, IPositiveDecimal multiplier) => PositiveDecimal
        .Create(positiveDecimal.Amount * multiplier.Amount)
        .Data;

    /// <summary>
    /// Divides two positive decimal values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <param name="dividend"></param>
    /// <returns></returns>
    public static Result<INonNegativeDecimal> DivideBy(this IPositiveDecimal positiveDecimal, IPositiveDecimal dividend) => DecimalFactory
        .CreateNonNegative(positiveDecimal.Amount / dividend.Amount);

    public static INonNegativeDecimal DivideByOrThrow(this IPositiveDecimal positiveDecimal, IPositiveDecimal dividend) => DecimalFactory
        .CreateNonNegative(positiveDecimal.Amount / dividend.Amount)
        .Data;

    /// <summary>
    /// Adds two positive values together guaranteeing the result of the operation is also a positive decimal and wrapping all errors and exceptions in a result type
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <param name="additive"></param>
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

    /// <summary>
    /// Adds two positive decimals together or throws if the operation fails
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <param name="additive"></param>
    /// <exception cref="OverflowException">when bounds of <see cref="decimal"/> are exceeded</exception>
    /// <returns></returns>
    public static IPositiveDecimal PlusOrThrow(this IPositiveDecimal positiveDecimal, IPositiveDecimal additive) => PositiveDecimal
        .Create(positiveDecimal.Amount + additive.Amount)
        .Data;
}