using Money.Decimals;

namespace Money;

public interface INonNegativeFunds : IFunds {
    INonNegativeDecimal Amount { get; }
}