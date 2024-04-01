using Results;

namespace Money.Currencies.RateService;

public interface IRateService
{
    Task<Result<ConversionRate>> GetRate(Currency from, Currency to);
}