using Money.Currencies.Converters;
using Money.Decimals;
using Money.Decimals.Math;
using Results;

namespace Money.FundsMath;

public class DefaultDebtMath {
    private readonly IDebtCurrencyConverter _converter;

    public DefaultDebtMath(IDebtCurrencyConverter converter) {
        _converter = converter;
    }
    public Task<Result<Debt>> Plus(Debt first, Debt second) => Apply(first, second, SameCurrencyPlus);
    private delegate Result<Debt> DebtMathOperation(Debt first, Debt second);

    private async Task<Result<Debt>> Apply(Debt first, Debt second, DebtMathOperation sameCurrencyOperation) => first.Currency == second.Currency
        ? sameCurrencyOperation(first, second)
        : await _converter.Convert(second, first.Currency)
            .MapAsync(converted => sameCurrencyOperation(first, converted));

    private Result<Debt> SameCurrencyPlus(Debt first, Debt second) => first.DebtAmount
        .Plus(second.DebtAmount)
        .Map(total => new Debt(total, first.Currency));
    
}