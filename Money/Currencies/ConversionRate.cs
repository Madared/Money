using Results;

namespace Money.Currencies;

public record ConversionRate : IPositiveDecimal
{
    public decimal Amount { get; }

    private ConversionRate(decimal value)
    {
        if (value <= 0) throw new InvalidDataException();
        Amount = value;
    }
    public static ConversionRate One() => new(1);

    public static Result<ConversionRate> Create(decimal value) => value <= 0
        ? Result<ConversionRate>.Fail(new UnknownError())
        : Result<ConversionRate>.Ok(new ConversionRate(value));

    public static implicit operator decimal(ConversionRate rate) => rate.Amount;
}