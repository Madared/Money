using ResultAndOption.Results;

namespace MoneyManagement.Validators;

public interface IValidator<T> where T : notnull
{
    public Result<T> Validate(T value);
}