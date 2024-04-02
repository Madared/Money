using System.Security.Cryptography.X509Certificates;

namespace Money.Decimals;

public record ZeroDecimal() : INonNegativeDecimal, INonPositiveDecimal {
    public decimal Amount => 0;

    public static implicit operator decimal(ZeroDecimal zero) => 0;
}