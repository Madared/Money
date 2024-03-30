namespace Money;

public interface IFunds {
    decimal Amount { get; }
    Currency.Currency Currency { get; }
}

public static class FundsGenerator {
    public static IFunds Create(decimal amount, Currency.Currency currency) => amount switch {
        < 0 => new Debt(NegativeDecimal.Create(amount).Data, currency),
        > 0 => new Money(PositiveDecimal.Create(amount).Data, currency),
        _ => new NoMoney(currency)
    };
}