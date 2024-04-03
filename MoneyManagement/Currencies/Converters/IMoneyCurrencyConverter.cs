using Results;

namespace MoneyManagement.Currencies.Converters;

public interface IMoneyCurrencyConverter : IFundsCurrencyConverter<Funds.Money>
{
    Task<Result<Funds.Money>> Convert(Funds.Money toConvert, Currency convertTo);
}