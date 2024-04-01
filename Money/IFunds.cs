using Money.Currencies;

namespace Money;

public interface IFunds {
    decimal Amount { get; }
    Currency Currency { get; }
}