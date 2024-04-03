using MoneyManagement.Currencies;

namespace Tests;

public class CurrencySymbolTests
{
    private const string Value = "100,50";
    [Fact]
    public void Prefix_Symbol_Correctly_Added_Without_Space()
    {
        CurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.prefix, false);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("$100,50", withValue);
    }

    [Fact]
    public void Prefix_Symbol_Correctly_Added_With_Space()
    {
        CurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.prefix, true);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("$ 100,50", withValue);
    }

    [Fact]
    public void Postfix_Symbol_Correctly_Added_Without_Space()
    {
        CurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.postfix, false);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("100,50$", withValue);
    }

    [Fact]
    public void PostFix_Symbol_Correctly_Added_With_Space()
    {
        CurrencySymbol symbol = new("$", "USD", CurrencySymbolPosition.postfix, true);
        string withValue = symbol.AddSymbol(Value);
        Assert.Equal("100,50 $", withValue);
    }

    [Fact]
    public void Separator_Symbol_Is_Correctly_Added_And_Not_Affected_By_Space()
    {
        CurrencySymbol spacedSymbol = new("$", "USD", CurrencySymbolPosition.separator, true);
        CurrencySymbol nonSpacedSymbol = new("$", "USD", CurrencySymbolPosition.separator, false);
        Assert.Equal(spacedSymbol.AddSymbol(Value), nonSpacedSymbol.AddSymbol(Value));
    }
}