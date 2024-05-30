namespace MoneyManagement.Currencies;

public sealed record CurrencyPrecisions(
    DecimalPrecisionValue MathematicalPrecision,
    DecimalPrecisionValue DisplayPrecision);