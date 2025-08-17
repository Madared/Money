namespace MoneyManagement;

public static class StringExtensions
{
    public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);
    public static bool IsWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);
}