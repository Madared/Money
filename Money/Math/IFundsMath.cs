using Results;

namespace Money.Math;

public interface IFundsMath<T> where T : IFunds {
    Task<Result<T>> Plus(T first, T second);
    Task<Result<T>> Times(T first, T second);
    Task<Result<T>> Divide(T first, T second);
    Task<Result<T>> Minus(T first, T second);
}