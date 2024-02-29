using Results;

namespace Money;

public interface IRateService
{
    Task<Result<ConversionRate>> GetRate(Currency from, Currency to);
}