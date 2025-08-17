using MoneyManagement.Errors;
using MoneyManagement.Validators;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement;

public sealed record CurrencyName
{
    private string StringName { get; }

    private CurrencyName(string name)
    {
        if (name.IsEmpty()) throw new InvalidOperationException();
        StringName = name;
    }

    public static Result<CurrencyName> Create(string name, IValidator<string> validator) => validator
        .Validate(name)
        .Map(validName => new CurrencyName(validName));

    public static implicit operator string(CurrencyName currencyName) => currencyName.StringName;
}