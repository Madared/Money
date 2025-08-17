using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions.Async;

namespace MoneyManagement.Currencies.RateService;

public sealed class BackedUpRateService : IRateService
{
    private readonly IRateService _main;
    private readonly IRateService _backup;

    public BackedUpRateService(IRateService main)
    {
        _main = main;
    }

    public async Task<Result<ConversionRate>> GetRate(Currency from, Currency to) => await _main
        .GetRate(from, to)
       .OnErrorAsync(_ => _backup.GetRate(from, to));
}