using Money.Decimals;

namespace Money;

public interface INonPositiveFunds : IFunds {
    INonPositiveDecimal Amount { get; }
}