using MoneyManagement.Decimals;

namespace MoneyManagement.Funds;

public interface INonPositiveFunds : IFunds {
    INonPositiveDecimal Amount { get; }
}