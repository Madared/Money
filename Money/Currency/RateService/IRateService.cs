using Results;

namespace Money.Currency.RateService;

public interface IRateService
{
    Task<Result<ConversionRate>> GetRate(Currency from, Currency to);
}