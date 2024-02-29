namespace Money;

public record CurrencySeparators(string DecimalSeparator, string ThousandSeparator)
{
    private bool IsThousand(int totalLength, int index, DecimalPrecisionValue precision)
    {
        int value = totalLength - 1 - index - precision;
        return value > 0 && value % 3 == 0;
    }

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

    private bool IsDefaultSeparator(char separator) => separator == ',' || separator == '.';

    public string ReplaceDecimalSeparator(string value, DecimalPrecisionValue precision)
    {
        int index = value.Length - 1 - precision;
        return IsDefaultSeparator(value[index])
            ? value.Remove(index, 1).Insert(index, DecimalSeparator)
            : throw new InvalidPrecisionSpecified(value, precision);
    }
}