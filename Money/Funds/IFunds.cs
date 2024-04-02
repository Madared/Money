using Money.Currencies;

namespace Money.Funds;

public interface IFunds {
    decimal Amount { get; }
    Currency Currency { get; }
}