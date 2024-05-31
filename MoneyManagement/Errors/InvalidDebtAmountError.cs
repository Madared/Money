using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement;

public class InvalidDebtAmountError : IError {
    public InvalidDebtAmountError(decimal amount) {
        Message = String.Format("{amount} is not a valid debt amount", amount);
    }
    public string Message { get; }
}