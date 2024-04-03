using System.Globalization;
using MoneyManagement.Currencies;

namespace Tests;

public class CurrencySeparatorTests
{
    private readonly CurrencySeparators _separators = new("#", "_");

    [Fact]
    public void Thousand_Separator_Gets_Added_At_Thousands()
    {
        DecimalPrecisionValue precision = DecimalPrecisionValue.Create(2).Data;
        string toReplace = "1000000.50";
        string replaced = _separators.AddThousandSeparator(toReplace, precision);
        Assert.Equal("1_000_000.50", replaced);
    }

    [Fact]
    public void Decimal_Separator_Gets_Properly_Replaced()
    {
        decimal value = 100.50M;
        string stringedValue = value.ToString(CultureInfo.InvariantCulture);
        string replaced = _separators.ReplaceDecimalSeparator(stringedValue, DecimalPrecisionValue.Two());
        Assert.Equal("100#50", replaced);
    }
}