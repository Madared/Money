namespace MoneyManagement.Currencies;

public record CurrencyPrecisions(
    DecimalPrecisionValue MathematicalPrecision,
    DecimalPrecisionValue DisplayPrecision);