using Money.Currencies.Converters;
using Results;

namespace Money.Comparers;

public class DefaultFundsComparer : IFundsComparer {
    private readonly IFundsCurrencyConverter _converter;

    public DefaultFundsComparer(IFundsCurrencyConverter converter) {
        _converter = converter;
    }

    public Task<Result<FundsComparison>> Compare(IFunds first, IFunds second) {
        if (first.Currency == second.Currency) {
            return Task.FromResult(Result<FundsComparison>.Ok(SameCurrencyComparing(first, second)));
        }

        return _converter
            .Convert(second, first.Currency)
            .MapAsync(converted => SameCurrencyComparing(first, converted));
    }
    private static FundsComparison SameCurrencyComparing(IFunds first, IFunds second) {
        if (first.Amount > second.Amount) return FundsComparison.Greater;
        if (first.Amount < second.Amount) return FundsComparison.Lesser;
        return FundsComparison.Equal;
    }
}