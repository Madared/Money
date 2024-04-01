using Money.Currencies;
using Results;

namespace Money;

public interface IFunds {
    decimal Amount { get; }
    Currency Currency { get; }
}