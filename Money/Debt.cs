using Money.Currencies;
using Money.Decimals;
using Results;

namespace Money;

public record Debt(INegativeDecimal DebtAmount, Currency Currency) : INonPositiveFunds
{
    decimal IFunds.Amount => DebtAmount.Amount;
    INonPositiveDecimal INonPositiveFunds.Amount => DebtAmount;

    public static Result<Debt> Create(decimal amount, Currency currency) {
        Result<NegativeDecimal> negative = NegativeDecimal.Create(amount);
        return negative.Failed
            ? Result<Debt>.Fail(new InvalidDebtAmountError(amount))
            : Result<Debt>.Ok(new Debt(negative.Data, currency));
    }
}