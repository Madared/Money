using Money.Currency.Converters;

namespace Money.Comparers;

public class DefaultFundsComparer : IComparer<IFunds> {
    private readonly IFundsCurrencyConverter _converter;
    
    public int Compare(IFunds? x, IFunds? y) {
        if (x.Currency == y.Currency) {
            
        }
    }

    private static int SameCurrencyComparison(IFunds x, IFunds y) {
        
    }
}