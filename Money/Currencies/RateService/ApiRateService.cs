using Results;

namespace Money.Currencies.RateService;

public class ApiRateService : IRateService
{
    private HttpClient _client;

    public ApiRateService(HttpClient client)
    {
        _client = client;
    }
    public async Task<Result<ConversionRate>> GetRate(Currency from, Currency to)
    {
        return await Task.FromResult(Result<ConversionRate>.Fail(new UnknownError()));
    }
}