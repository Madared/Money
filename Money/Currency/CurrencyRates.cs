namespace Money.Currency;

public record CurrencyRates(
    ConversionRate ToDollar,
    DecimalPrecisionValue MathematicalPrecision,
    DecimalPrecisionValue DisplayPrecision);