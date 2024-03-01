using Money.Errors;
using Results;

namespace Money;

public record PositiveDecimal : IPositiveDecimal
{
    public decimal Amount { get; }

    private static bool IsNegativeOrZero(decimal amount) => amount <= 0;

    private PositiveDecimal(decimal amount)
    {
        if (IsNegativeOrZero(amount)) throw new InvalidPositiveDecimal(amount);
        Amount = amount;
    }

    /// <summary>
    /// Attempts to create a valid Positive Decimal instance from the passed in decimal value
    /// </summary>
    /// <param name="amount">any decimal value</param>
    /// <returns>A result type containing either a valid Positive Decimal or an error</returns>
    public static Result<PositiveDecimal> Create(decimal amount) => IsNegativeOrZero(amount)
        ? Result<PositiveDecimal>.Fail(new InvalidPositiveDecimal(amount))
        : Result<PositiveDecimal>.Ok(new PositiveDecimal(amount));

    public static PositiveDecimal One() => new PositiveDecimal(1);

    /// <inheritdoc cref="IPositiveDecimal.Times"/>
    public IPositiveDecimal Times(IPositiveDecimal positiveDecimal) =>
        new PositiveDecimal(Amount * positiveDecimal.Amount);

    /// <inheitdoc cref="IPositiveDecimal.DivideBy"/>
    public IPositiveDecimal DivideBy(IPositiveDecimal positiveDecimal) =>
        new PositiveDecimal(Amount / positiveDecimal.Amount);

    /// <inheritdoc cref="IPositiveDecimal.Plus"/>
    public IPositiveDecimal Plus(IPositiveDecimal positiveDecimal) =>
        new PositiveDecimal(Amount + positiveDecimal.Amount);
}