using ResultAndOption.Errors;

namespace MoneyManagement;

public class InvalidMoneyAmountError : IError {
    public string Message { get; }
    public InvalidMoneyAmountError(decimal amount) {
        Message = String.Format("{amount} is not a valid amount of money", amount);
    }
}