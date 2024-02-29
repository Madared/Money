using Results;

namespace Money.Currency.RateService;

public interface IRateService
{
    Task<Result<ConversionRate>> GetRate(global::Money.Currency.Currency from, global::Money.Currency.Currency to);
}