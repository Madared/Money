using MoneyManagement.Decimals;
using MoneyManagement.Validators;
using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Currencies;

public sealed record ConversionRate 
{
    public PositiveDecimal Amount { get; }

    public ConversionRate(PositiveDecimal value) => Amount = value;
    public static ConversionRate One() => new(PositiveDecimal.Create(1).Data);
    public static implicit operator decimal(ConversionRate rate) => rate.Amount;
    public static implicit operator PositiveDecimal(ConversionRate rate) => rate.Amount;
}