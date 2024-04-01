using Results;

namespace Money.Currencies.RateService;

public class DefaultRateService : IRateService
{
    public Task<Result<ConversionRate>> GetRate(Currency from, Currency to)
    {
        decimal rate = from.Rates.ToDollar / to.Rates.ToDollar;
        return Task.FromResult(ConversionRate.Create(rate));
    }
}