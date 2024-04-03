using Money.Errors;
using Results;

namespace Money.Decimals;

public record PositiveDecimal : IPositiveDecimal
{
    public decimal Amount { get; }


    private PositiveDecimal(decimal amount)
    {
        if (!IPositiveDecimal.IsPositive(amount)) throw new InvalidPositiveDecimal(amount);
        Amount = amount;
    }

    /// <summary>
    /// Attempts to create a valid Positive Decimal instance from the passed in decimal value
    /// </summary>
    /// <param name="amount">any decimal value</param>
    /// <returns>A result type containing either a valid Positive Decimal or an error</returns>
    public static Result<PositiveDecimal> Create(decimal amount) => IPositiveDecimal.IsPositive(amount)
        ? Result<PositiveDecimal>.Ok(new PositiveDecimal(amount))
        : Result<PositiveDecimal>.Fail(new InvalidPositiveDecimal(amount));
}