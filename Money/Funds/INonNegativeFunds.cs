using Money.Decimals;

namespace Money.Funds;

public interface INonNegativeFunds : IFunds {
    INonNegativeDecimal Amount { get; }
}