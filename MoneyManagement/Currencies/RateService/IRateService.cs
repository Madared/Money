using ResultAndOption.Results;

namespace MoneyManagement.Currencies.RateService;

public interface IRateService
{
    Task<Result<ConversionRate>> GetRate(Currency from, Currency to);
}