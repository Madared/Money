using MoneyManagement.Currencies;
using MoneyManagement.Decimals;
using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;
using ResultAndOption.Results.SimpleResultExtensions;

namespace MoneyManagement.Funds;

public static class FundsFactory {
    public static IFunds Create(decimal amount, Currency currency) => amount switch {
        < 0 => NegativeDecimal.Create(amount)
            .Map(negativeAmount => new NegativeDecimal(negativeAmount))
            .Map(negative => new Debt(negative, currency)).Data,
        > 0 => PositiveDecimal.Create(amount)
            .Map(positive => new Money(positive, currency)).Data,
        _ => new NoMoney(currency)
    };

    public static Result<INonPositiveFunds> CreateNonPositive(decimal amount, Currency currency) => amount switch {
        < 0 => NegativeDecimal.Create(amount)
            .Map(negativeAmount => new NegativeDecimal(negativeAmount))
            .Map(negative => new Debt(negative, currency) as INonPositiveFunds),
        0 => Result<INonPositiveFunds>.Ok(new NoMoney(currency)),
        _ => Result<INonPositiveFunds>.Fail(new UnknownError())
    };

    public static Result<INonNegativeFunds> CreateNonNegative(decimal amount, Currency currency) => amount switch {
        > 0 => PositiveDecimal.Create(amount)
            .Map(positive => new Money(positive, currency) as INonNegativeFunds),
        0 => Result<INonNegativeFunds>.Ok(new NoMoney(currency)),
        _ => Result<INonNegativeFunds>.Fail(new UnknownError())
    };

    public static INonNegativeFunds CreateNonNegative(INonNegativeDecimal amount, Currency currency) => amount
        .AsPositive()
        .Map(positive => new PositiveDecimal(positive))
        .Map(positive => new Money(positive, currency) as INonNegativeFunds)
        .Or(new NoMoney(currency));

    public static INonPositiveFunds CreateNonPositive(INonPositiveDecimal amount, Currency currency) => amount
        .AsNegative()
        .Map(negativeAmount => new NegativeDecimal(negativeAmount))
        .Map(negative => new Debt(negative, currency) as INonPositiveFunds)
        .Or(new NoMoney(currency));

}