using MoneyManagement.Currencies;
using MoneyManagement.Decimals;
using ResultAndOption;
using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds;

public sealed record Money(PositiveDecimal CashAmount, Currency Currency) : INonNegativeFunds {
    decimal IFunds.Amount => CashAmount.Amount;
    INonNegativeDecimal INonNegativeFunds.Amount => CashAmount;

    public static Result<Money> Create(decimal amount, Currency formattableCurrency)
    {
        Result<PositiveDecimal> positive = PositiveDecimal.Create(amount);
        return positive.Failed 
            ? Result<Money>.Fail(new InvalidMoneyAmountError(amount)) 
            : new Money(positive.Data, formattableCurrency).ToResult(new UnknownError());
    }
}