namespace Money;

public interface IPositiveDecimal
{
    decimal Amount { get; }

    /// <summary>
    /// Multiplies two positive decimal values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    IPositiveDecimal Times(IPositiveDecimal positiveDecimal);

    /// <summary>
    /// Divides two positive decimal values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    IPositiveDecimal DivideBy(IPositiveDecimal positiveDecimal);

    /// <summary>
    /// Adds two positive values together guaranteeing the result of the operation is also a positive decimal
    /// </summary>
    /// <param name="positiveDecimal"></param>
    /// <returns></returns>
    IPositiveDecimal Plus(IPositiveDecimal positiveDecimal);
}