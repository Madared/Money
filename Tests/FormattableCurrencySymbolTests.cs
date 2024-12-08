using MoneyManagement.Currencies;

namespace Tests;

public class FormattableCurrencySymbolTests
{
    private const string Value = "100,50";
    [Fact]
    public void Prefix_Symbol_Correctly_Added_Without_Space()
    {
        FormattableCurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.prefix, false);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("$100,50", withValue);
    }

    [Fact]
    public void Prefix_Symbol_Correctly_Added_With_Space()
    {
        FormattableCurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.prefix, true);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("$ 100,50", withValue);
    }

    [Fact]
    public void Postfix_Symbol_Correctly_Added_Without_Space()
    {
        FormattableCurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.postfix, false);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("100,50$", withValue);
    }

    [Fact]
    public void PostFix_Symbol_Correctly_Added_With_Space()
    {
        FormattableCurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.postfix, true);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("100,50 $", withValue);
    }

    [Fact]
    public void Separator_Symbol_Is_Correctly_Added_And_Not_Affected_By_Space()
    {
        FormattableCurrencySymbol spacedSymbol = new("$", "USD", CurrencySymbolPosition.separator, true);
        FormattableCurrencySymbol nonSpacedSymbol = new("$", "USD", CurrencySymbolPosition.separator, false);
        Assert.Equal(spacedSymbol.AddSymbol(Value), nonSpacedSymbol.AddSymbol(Value));
    }
}