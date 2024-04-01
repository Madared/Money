using Results;

namespace Money;

public class InvalidDebtAmountError : IError {
    public InvalidDebtAmountError(decimal amount) {
        Message = String.Format("{amount} is not a valid debt amount", amount);
    }
    public void Log(IErrorLogger logger) {
        throw new NotImplementedException();
    }

    public string Message { get; }
}