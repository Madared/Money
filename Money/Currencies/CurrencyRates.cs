namespace Money.Currencies;

public record CurrencyRates(
    ConversionRate ToDollar,
    DecimalPrecisionValue MathematicalPrecision,
    DecimalPrecisionValue DisplayPrecision);