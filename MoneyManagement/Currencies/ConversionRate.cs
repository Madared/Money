using MoneyManagement.Decimals;
using MoneyManagement.Validators;
using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Currencies;

public sealed record ConversionRate : IPositiveDecimal
{
    public decimal Amount { get; }

    private ConversionRate(decimal value) => Amount = value;
    public static ConversionRate One() => new(1);
    public static Result<ConversionRate> Create(decimal value, IValidator<decimal> validator) => validator
        .Validate(value)
        .Map(validValue => new ConversionRate(validValue));
    public static implicit operator decimal(ConversionRate rate) => rate.Amount;
}