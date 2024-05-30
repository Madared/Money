using MoneyManagement.Errors;
using Results;

namespace MoneyManagement;

public sealed record CurrencyName
{
    private string StringName { get; }

    private CurrencyName(string name)
    {
        if (name.IsEmpty()) throw new InvalidOperationException();
        StringName = name;
    }

    public static Result<CurrencyName> Create(string name) => name.IsEmpty()
        ? Result<CurrencyName>.Fail(new EmptyNameError())
        : Result<CurrencyName>.Ok(new CurrencyName(name));

    public static implicit operator string(CurrencyName currencyName) => currencyName.StringName;
}