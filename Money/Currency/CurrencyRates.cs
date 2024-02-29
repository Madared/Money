using System.Dynamic;

namespace Money;

public record CurrencyRates(
    ConversionRate ToDollar,
    DecimalPrecisionValue MathematicalPrecision,
    DecimalPrecisionValue DisplayPrecision);