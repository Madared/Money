using MoneyManagement.Currencies;
using MoneyManagement.Decimals;

namespace MoneyManagement.Funds;

public interface IFundsFactory
{
    public Money Money(PositiveDecimal amount, Currency currency);
    public Debt Debt(NegativeDecimal amount, Currency currency);
    public IFunds Zero(Currency currency);
    public IFunds Create(decimal amount, Currency currency);
}