using MoneyManagement.Currencies;

namespace MoneyManagement.Comparers;

public sealed class DefaultCurrencyEqualityComparer : IEqualityComparer<Currency>
{
    public bool Equals(Currency? x, Currency? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        return x.Name.Equals(y.Name) && x.Symbol.Equals(y.Symbol);
    }

    public int GetHashCode(Currency obj) => HashCode.Combine(obj.Name, obj.Symbol);
}