using Money.Currencies.RateService;
using Results;

namespace Money.Currencies.Converters;

/// <summary>
/// The default Funds Currency converter
/// </summary>
public class DefaultFundsCurrencyConverter : IFundsCurrencyConverter<IFunds> {
    private readonly IRateService _service;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service">The rate service which will be used in the conversion</param>
    public DefaultFundsCurrencyConverter(IRateService service) {
        _service = service;
    }

    /// <summary>
    /// Converts any funds type to specified currency asynchronously
    /// </summary>
    /// <param name="toConvert">The funds to convert</param>
    /// <param name="convertTo">The currency to convert to</param>
    /// <returns>the converted funds</returns>
    public Task<Result<IFunds>> Convert(IFunds toConvert, Currency convertTo) => _service
        .GetRate(toConvert.Currency, convertTo)
        .MapAsync(rate => toConvert.Amount * rate)
        .MapAsync(multiplied => FundsGenerator.Create(multiplied, convertTo));
}