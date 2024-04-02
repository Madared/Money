namespace Money.Decimals;

public interface INegativeDecimal : INonPositiveDecimal {
    decimal Amount { get; }
}