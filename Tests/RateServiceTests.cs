using MoneyManagement.Currencies;
using MoneyManagement.Currencies.RateService;
using Results;

namespace Tests;

public class RateServiceTests
{
    [Fact]
    public async void Backup_Rate_Service_Calls_All_Services()
    {
        FakeRateService main = new();
        BackedUpRateService backUpService = new(main);
        List<FakeRateService> fakeServices = new();
        for (int i = 0; i < 10; i++)
        {
            var fake = new FakeRateService();
            fakeServices.Add(fake);
            backUpService.AddBackup(fake);
        }

        await backUpService.GetRate(Currency.Dollar(), Currency.Dollar());
        Assert.True(fakeServices.All(value => value.Called));
    }
}

public class FakeRateService : IRateService
{
    public bool Called { get; private set; }

    public Task<Result<ConversionRate>> GetRate(Currency from, Currency to)
    {
        Called = true;
        return Task.FromResult(Result<ConversionRate>.Fail(new UnknownError()));
    }
}