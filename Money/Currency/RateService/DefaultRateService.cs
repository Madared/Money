using Results;

namespace Money.Currency.RateService;

public class DefaultRateService : IRateService
{
    public Task<Result<ConversionRate>> GetRate(global::Money.Currency.Currency from, global::Money.Currency.Currency to)
    {
        ConversionRate computedRate = from.Rates.ToDollar.DivideBy(to.Rates.ToDollar);
        return Task.FromResult(Result<ConversionRate>.Ok(computedRate));
    }
}