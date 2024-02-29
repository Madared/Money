namespace Money;

public static class StringExtensions
{
    public static bool IsEmpty(this string str) => str.Length == 0 || str.AsSpan().IsWhiteSpace();
}