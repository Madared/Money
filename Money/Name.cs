using Money.Errors;
using Results;

namespace Money;

public record Name
{
    public string StringName { get; }

    private Name(string name)
    {
        if (name.IsEmpty()) throw new InvalidOperationException();
        StringName = name;
    }

    public static Result<Name> Create(string name) => name.IsEmpty()
        ? Result<Name>.Fail(new EmptyNameError())
        : Result<Name>.Ok(new Name(name));

    public static implicit operator string(Name name) => name.StringName;
}