using Results;

namespace MoneyManagement;

public class InvalidMoneyAmountError : IError {
    public void Log(IErrorLogger logger) {
        throw new NotImplementedException();
    }

    public string Message { get; }

    public InvalidMoneyAmountError(decimal amount) {
        Message = String.Format("{amount} is not a valid amount of money", amount);
    }
}