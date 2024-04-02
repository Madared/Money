using Money.Decimals;

namespace Money.Funds;

public interface INonPositiveFunds : IFunds {
    INonPositiveDecimal Amount { get; }
}