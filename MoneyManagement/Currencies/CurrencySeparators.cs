using MoneyManagement.Errors;

namespace MoneyManagement.Currencies;

public sealed record CurrencySeparators(string DecimalSeparator, string ThousandSeparator)
{
    /// <summary>
    /// Adds the thousand separator to the string representation of a decimal value
    /// </summary>
    /// <param name="value">string representation of decimal value</param>
    /// <param name="displayPrecision">the number of significant values after the decimal separator</param>
    /// <returns></returns>
    public string AddThousandSeparator(string value, DecimalPrecisionValue displayPrecision)
    {
        string final = "";
        for (int i = value.Length - 1; i >= 0; i--)
        {
            final = IsThousand(value.Length, i, displayPrecision)
                ? ThousandSeparator + value[i] + final
                : value[i] + final;
        }

        return final;
    }


    /// <summary>
    /// Replaces the default decimal CultureInvariant separator of a string representation of a value
    /// </summary>
    /// <param name="value">string representation of decimal value</param>
    /// <param name="precision">The number of significant values after the decimal separator</param>
    /// <returns></returns>
    /// <exception cref="InvalidPrecisionSpecified"></exception>
    public string ReplaceDecimalSeparator(string value, DecimalPrecisionValue precision)
    {
        int index = value.Length - 1 - precision;
        return IsDefaultSeparator(value[index])
            ? value.Remove(index, 1).Insert(index, DecimalSeparator)
            : throw new InvalidPrecisionSpecified(value, precision);
    }

    private static bool IsThousand(int totalLength, int index, DecimalPrecisionValue precision)
    {
        int value = totalLength - 1 - index - precision;
        return value > 0 && value % 3 == 0;
    }

    private static bool IsDefaultSeparator(char separator) => separator is ',' or '.';
}