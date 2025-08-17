namespace MoneyManagement.Decimals;

public static class DecimalExtensions
{
    public static bool IsNegative(this decimal value) => value < 0;
    public static bool IsPositive(this decimal value) => value > 0;
    public static bool IsZero(this decimal value) => value == 0;
    public static bool IsNonNegative(this decimal value) => value.IsPositive() || value.IsZero();
    public static bool IsNonPositive(this decimal value) => value.IsNegative() || value.IsZero();
}