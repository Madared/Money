using Results;

namespace Money;

public class DefaultRateService : IRateService
{
    public Task<Result<ConversionRate>> GetRate(Currency from, Currency to)
    {
        ConversionRate computedRate = from.Rates.ToDollar.DivideBy(to.Rates.ToDollar);
        return Task.FromResult(Result<ConversionRate>.Ok(computedRate));
    }
}