using MoneyManagement.Currencies;
using MoneyManagement.Decimals;
using Results;

namespace MoneyManagement.Funds;

public static class FundsFactory {
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

    public static INonNegativeFunds CreateNonNegative(INonNegativeDecimal amount, Currency currency) => amount
        .AsPositive()
        .Map<INonNegativeFunds>(positive => new Money(positive, currency))
        .Or(new NoMoney(currency));

    public static INonPositiveFunds CreateNonPositive(INonPositiveDecimal amount, Currency currency) => amount
        .AsNegative()
        .Map<INonPositiveFunds>(negative => new Debt(negative, currency))
        .Or(new NoMoney(currency));

}