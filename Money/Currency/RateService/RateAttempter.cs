using Results;

namespace Money.Currency.RateService;

public class RateAttempter
{
    public Option<ConversionRate> ObtainedRate { get; private set; } = Option<ConversionRate>.None();

    public async Task Attempt(IRateService service, global::Money.Currency.Currency from, global::Money.Currency.Currency to)
    {
        Result<ConversionRate> result = await service.GetRate(from, to);
        if (result.Succeeded)
        {
            ObtainedRate = Option<ConversionRate>.Some(result.Data);
        }
    }
}