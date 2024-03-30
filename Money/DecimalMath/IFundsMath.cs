using Results;

namespace Money.DecimalMath;

public interface IFundsMath<T> where T : IFunds {
    Task<Result<T>> Plus(T first, T second);
    Task<Result<T>> Times(T first, T second);
    Task<Result<T>> Divide(T first, T second);
    Task<Result<T>> Minus(T first, T second);
}