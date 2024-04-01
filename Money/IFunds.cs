using Money.Currencies;
using Money.Decimals;
using Results;

namespace Money;

public interface IFunds {
    decimal Amount { get; }
    Currency Currency { get; }
}