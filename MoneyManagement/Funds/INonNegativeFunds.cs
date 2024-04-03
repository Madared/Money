using MoneyManagement.Decimals;

namespace MoneyManagement.Funds;

public interface INonNegativeFunds : IFunds {
    INonNegativeDecimal Amount { get; }
}