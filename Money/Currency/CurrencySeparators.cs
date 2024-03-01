using Money.Errors;

namespace Money.Currency;

public record CurrencySeparators(string DecimalSeparator, string ThousandSeparator)
{
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