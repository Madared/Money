namespace Money;
public interface IPositiveDecimal
{
    decimal Amount { get; }
    IPositiveDecimal Times(IPositiveDecimal positiveDecimal);
    IPositiveDecimal DivideBy(IPositiveDecimal positiveDecimal);
    IPositiveDecimal Plus(IPositiveDecimal positiveDecimal);
}