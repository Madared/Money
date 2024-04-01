using Money.Currencies;
using Money.Decimals;
using Results;

namespace Money;

public record Money(IPositiveDecimal CashAmount, Currency Currency) : INonNegativeFunds {
    decimal IFunds.Amount => CashAmount.Amount;

    public static IFunds Create(INonNegativeDecimal nonNegativeDecimal, Currency currency) {
        if (nonNegativeDecimal.IsZero()) return new NoMoney(currency);
        return PositiveDecimal
            .Create(nonNegativeDecimal.Amount)
            .Map(amount => new Money(amount, currency))
            .Data;
    }
}

public interface INonNegativeDecimal {
    decimal Amount { get; }
    bool IsZero();
}

public record NonNegativeDecimal : INonNegativeDecimal {
    public decimal Amount { get; }
    public bool IsZero() => Amount == decimal.Zero;

    private NonNegativeDecimal(decimal amount) {
        if (amount < 0) throw new InvalidDataException();
        Amount = amount;
    }

    public static Result<NonNegativeDecimal> Create(decimal amount) => amount < 0
        ? Result<NonNegativeDecimal>.Fail(new UnknownError())
        : Result<NonNegativeDecimal>.Ok(new NonNegativeDecimal(amount));
}