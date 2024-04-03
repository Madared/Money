using MoneyManagement.Currencies;

namespace MoneyManagement.Funds;

public interface IFunds {
    decimal Amount { get; }
    Currency Currency { get; }
}