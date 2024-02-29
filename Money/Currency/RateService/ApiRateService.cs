using Results;

namespace Money.Currency.RateService;

public class ApiRateService : IRateService
{
    private HttpClient _client;

    public ApiRateService(HttpClient client)
    {
        _client = client;
    }
    public async Task<Result<ConversionRate>> GetRate(global::Money.Currency.Currency from, global::Money.Currency.Currency to)
    {
        return await Task.FromResult(Result<ConversionRate>.Fail(new UnknownError()));
    }
}