using Results;

namespace Money;

public record DecimalPrecisionValue
{
    private int Value { get; }

    private DecimalPrecisionValue(int value)
    {
        if (value < 0) throw new InvalidDataException();
        Value = value;
    }

    public static DecimalPrecisionValue One() => new(1);
    public static DecimalPrecisionValue Two() => new(2);
    public static DecimalPrecisionValue Three() => new(3);
    public static DecimalPrecisionValue Four() => new(4);

    public static Result<DecimalPrecisionValue> Create(int value) => value < 0
        ? Result<DecimalPrecisionValue>.Fail(new UnknownError())
        : Result<DecimalPrecisionValue>.Ok(new DecimalPrecisionValue(value));

    public static implicit operator int(DecimalPrecisionValue value) => value.Value;
}