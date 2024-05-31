using ResultAndOption.Errors;

namespace MoneyManagement.Errors;

public class EmptyNameError : Exception, IError
{
    public EmptyNameError() : base("Name cannot be empty") {}
}