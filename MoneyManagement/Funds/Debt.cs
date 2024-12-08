using MoneyManagement.Currencies;
using MoneyManagement.Decimals;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Funds;

public sealed record Debt(NegativeDecimal DebtAmount, Currency Currency) : INonPositiveFunds
{
    decimal IFunds.Amount => DebtAmount.Amount;
    INonPositiveDecimal INonPositiveFunds.Amount => DebtAmount;

    public static Result<Debt> Create(decimal amount, FormattableCurrency currency)
    {
        Result<NegativeDecimal> negative = NegativeDecimal
            .Create(amount);
        return negative.Failed
            ? Result<Debt>.Fail(new InvalidDebtAmountError(amount))
            : Result<Debt>.Ok(new Debt(negative.Data, currency));
    }
}