namespace Money;

public interface IFunds
{
    decimal Amount { get; }
    Currency.Currency Currency { get; }

}