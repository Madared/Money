using Results;

namespace Money.Currency;

public record ConversionRate : IPositiveDecimal
{
    public decimal Amount { get; }

    private ConversionRate(decimal value)
    {
        if (value <= 0) throw new InvalidDataException();
        Amount = value;
    }

    ///<inheritdoc cref="IPositiveDecimal.Times"/>
    public ConversionRate Times(IPositiveDecimal positiveDecimal) =>
        Create(Amount * positiveDecimal.Amount).Data;

    ///<inheritdoc cref="IPositiveDecimal.Times"/>>
    public ConversionRate Plus(IPositiveDecimal positiveDecimal) =>
        Create(Amount + positiveDecimal.Amount).Data;

    ///<inheritdoc cref="IPositiveDecimal.Times"/>>
    public ConversionRate DivideBy(IPositiveDecimal positiveDecimal) =>
        Create(Amount / positiveDecimal.Amount).Data;

    IPositiveDecimal IPositiveDecimal.Times(IPositiveDecimal positiveDecimal) => Times(positiveDecimal);
    IPositiveDecimal IPositiveDecimal.DivideBy(IPositiveDecimal positiveDecimal) => DivideBy(positiveDecimal);
    IPositiveDecimal IPositiveDecimal.Plus(IPositiveDecimal positiveDecimal) => Plus(positiveDecimal);

    public static ConversionRate One() => new(1);

    public static Result<ConversionRate> Create(decimal value) => value <= 0
        ? Result<ConversionRate>.Fail(new UnknownError())
        : Result<ConversionRate>.Ok(new ConversionRate(value));

    public static implicit operator decimal(ConversionRate rate) => rate.Amount;
}