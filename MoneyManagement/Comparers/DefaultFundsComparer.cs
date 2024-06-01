using MoneyManagement.Currencies.Converters;
using MoneyManagement.Funds;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions.Async;

namespace MoneyManagement.Comparers;

public sealed class DefaultFundsComparer : IFundsComparer
{
    private readonly IFundsCurrencyConverter _converter;

    public DefaultFundsComparer(IFundsCurrencyConverter converter)
    {
        _converter = converter;
    }

    public Task<Result<FundsComparison>> Compare(IFunds first, IFunds second)
    {
        if (first.Currency != second.Currency)
        {
            return _converter
                .Convert(second, first.Currency)
                .MapAsync(converted => SameCurrencyComparing(first, converted));
        }

        FundsComparison comparison = SameCurrencyComparing(first, second);
        Result<FundsComparison> comparisonResult = Result<FundsComparison>.Ok(comparison);
        return Task.FromResult(comparisonResult);
    }

    private static FundsComparison SameCurrencyComparing(IFunds first, IFunds second)
    {
        if (first.Amount > second.Amount) return FundsComparison.Greater;
        if (first.Amount < second.Amount) return FundsComparison.Lesser;
        return FundsComparison.Equal;
    }
}