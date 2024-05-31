using MoneyManagement.Currencies;
using MoneyManagement.Decimals;
using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds;

public sealed record Money(IPositiveDecimal CashAmount, Currency Currency) : INonNegativeFunds {
    decimal IFunds.Amount => CashAmount.Amount;
    INonNegativeDecimal INonNegativeFunds.Amount => CashAmount;

    public static Result<Money> Create(decimal amount, Currency currency) {
        Result<PositiveDecimal> positive = PositiveDecimal.Create(amount);
        return positive.Failed 
            ? Result<Money>.Fail(new InvalidMoneyAmountError(amount)) 
            : new Money(positive.Data, currency).ToResult(new UnknownError());
    }
}