using Results;

namespace MoneyManagement.Currencies.RateService;

public class BackedUpRateService : IRateService
{
    private readonly IRateService _main;
    private readonly List<IRateService> _backups = new();

    public BackedUpRateService(IRateService main)
    {
        _main = main;
    }

    public void AddBackup(IRateService service) => _backups.Add(service);

    private async Task<Result<ConversionRate>> TryBackups(Currency from, Currency to)
    {
        RateAttempter attempter = new();
        int index = 0;

        while (attempter.ObtainedRate.IsNone() && index < _backups.Count)
        {
            await attempter.Attempt(_backups[index], from, to);
            index++;
        }
        return attempter.ObtainedRate.IsNone()
            ? Result<ConversionRate>.Fail(new UnknownError())
            : Result<ConversionRate>.Ok(attempter.ObtainedRate.Data);
    }

    public async Task<Result<ConversionRate>> GetRate(Currency from, Currency to)
    {
        Result<ConversionRate> result = await _main.GetRate(from, to);
        if (result.Succeeded) return result;
        return await TryBackups(from, to);
    }
}