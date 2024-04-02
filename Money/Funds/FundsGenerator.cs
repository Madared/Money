using Money.Currencies;
using Money.Decimals;
using Results;

namespace Money.Funds;

public static class FundsGenerator {
    public static IFunds Create(decimal amount, Currency currency) => amount switch {
        < 0 => NegativeDecimal.Create(amount).Map<IFunds>(negative => new Debt(negative, currency)).Data,
        > 0 => PositiveDecimal.Create(amount).Map<IFunds>(positive => new Money(positive, currency)).Data,
        _ => new NoMoney(currency)
    };

    public static Result<INonPositiveFunds> CreateNonPositive(decimal amount, Currency currency) => amount switch {
        < 0 => NegativeDecimal.Create(amount).Map<INonPositiveFunds>(negative => new Debt(negative, currency)),
        0 => Result<INonPositiveFunds>.Ok(new NoMoney(currency)),
        _ => Result<INonPositiveFunds>.Fail(new UnknownError())
    };

    public static Result<INonNegativeFunds> CreateNonNegative(decimal amount, Currency currency) => amount switch {
        > 0 => PositiveDecimal.Create(amount).Map<INonNegativeFunds>(positive => new Money(positive, currency)),
        0 => Result<INonNegativeFunds>.Ok(new NoMoney(currency)),
        _ => Result<INonNegativeFunds>.Fail(new UnknownError())
    };

}