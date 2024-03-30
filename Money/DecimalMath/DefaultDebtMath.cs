using Money.Currency.Converters;
using Results;

namespace Money.DecimalMath;

public class DefaultDebtMath : IDebtMath {
    private readonly IDebtCurrencyConverter _converter;
    
    public DefaultDebtMath(IDebtCurrencyConverter converter) {
        _converter = converter;
    }

    public async Task<Result<Debt>> Plus(Debt first, Debt second) {
        if (first.Currency == second.Currency) {
            return SameCurrencyPlus(first, second).ToResult(new UnknownError());
        }

        return await _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyPlus(first, converted));
    }

    private Debt SameCurrencyPlus(Debt first, Debt second) => first.DebtAmount
        .Plus(second.DebtAmount)
        .PipeNonNull(total => new Debt(total, first.Currency));
}