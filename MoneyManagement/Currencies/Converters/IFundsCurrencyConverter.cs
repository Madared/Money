using MoneyManagement.Funds;
using Results;

namespace MoneyManagement.Currencies.Converters;

public interface IFundsCurrencyConverter<T> where T : IFunds {
    public Task<Result<T>> Convert(T toConvert, Currency convertTo);
}

public interface IFundsCurrencyConverter : IFundsCurrencyConverter<IFunds> {
    
}