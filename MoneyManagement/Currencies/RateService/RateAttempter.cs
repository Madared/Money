using ResultAndOption.Options;
using ResultAndOption.Results;

namespace MoneyManagement.Currencies.RateService;

internal sealed class RateAttempter
{
    public Option<ConversionRate> ObtainedRate { get; private set; } = Option<ConversionRate>.None();

    public async Task Attempt(IRateService service, Currency from, Currency to)
    {
        Result<ConversionRate> result = await service.GetRate(from, to);
        if (result.Succeeded)
        {
            ObtainedRate = Option<ConversionRate>.Some(result.Data);
        }
    }
}