using MoneyManagement.Errors;
using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Decimals;

public sealed record PositiveDecimal : INonNegativeDecimal
{
    public decimal Amount { get; }
    public Result<ZeroDecimal> AsZero() => Result<ZeroDecimal>.Fail(new UnknownError());
    public Result<PositiveDecimal> AsPositive() => Result<PositiveDecimal>.Ok(this);

    private PositiveDecimal(decimal amount)
    {
        if (amount.IsNonPositive())
        {
            throw new InvalidPositiveDecimal(amount);
        }
        Amount = amount;
    }

    /// <summary>
    /// Attempts to create a valid Positive Decimal instance from the passed in decimal value
    /// </summary>
    /// <param name="amount">any decimal value</param>
    /// <returns>A result type containing either a valid Positive Decimal or an error</returns>
    public static Result<PositiveDecimal> Create(decimal amount) => amount.IsPositive()
        ? Result<PositiveDecimal>.Ok(new PositiveDecimal(amount))
        : Result<PositiveDecimal>.Fail(new InvalidPositiveDecimal(amount));
    public static implicit operator decimal (PositiveDecimal positiveDecimal) => positiveDecimal.Amount;
}