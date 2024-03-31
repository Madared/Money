using Money.Currency.Converters;
using Results;

namespace Money.DecimalMath;

public class DefaultDebtMath {
    private readonly IDebtCurrencyConverter _converter;

    public DefaultDebtMath(IDebtCurrencyConverter converter) {
        _converter = converter;
    }

    public async Task<Result<Debt>> Plus(Debt first, Debt second) => first.Currency == second.Currency
        ? SameCurrencyPlus(first, second)
        : await _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyPlus(first, converted));

    private Result<Debt> SameCurrencyPlus(Debt first, Debt second) => first.DebtAmount
        .Plus(second.DebtAmount)
        .Map(total => new Debt(total, first.Currency));
}