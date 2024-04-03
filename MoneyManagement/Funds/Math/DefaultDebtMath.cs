using System.Runtime.CompilerServices;
using MoneyManagement.Decimals.Math;
using MoneyManagement.Currencies.Converters;
using MoneyManagement.Decimals;
using Results;

namespace MoneyManagement.Funds.Math;

public class DefaultDebtMath {
    private readonly IDebtCurrencyConverter _converter;
    private readonly IMoneyCurrencyConverter _moneyConverter;

    public DefaultDebtMath(IDebtCurrencyConverter converter, IMoneyCurrencyConverter moneyConverter) {
        _converter = converter;
        _moneyConverter = moneyConverter;
    }
    public Task<Result<Debt>> Plus(Debt first, Debt second) => Apply(first, second, SameCurrencyPlus);

    public async Task<Result<INonPositiveFunds>> ReduceDebt(Debt original, Money amountToReduce) {
        if (original.Currency == amountToReduce.Currency) {
            return FundsFactory.CreateNonPositive(original.DebtAmount.Amount - amountToReduce.CashAmount.Amount, original.Currency);
        }
        return await _moneyConverter
            .Convert(amountToReduce, original.Currency)
            .MapAsync(converted => original.DebtAmount.Amount - converted.CashAmount.Amount)
            .MapAsync(total => FundsFactory.CreateNonPositive(total, original.Currency));
    }

    public Result<Debt> Multiply(Debt original, IPositiveDecimal positive) => original.DebtAmount
        .TimesPositive(positive)
        .Map(multiplied => original with { DebtAmount = multiplied });

    public Debt MutltiplyOrThrow(Debt original, IPositiveDecimal positive) => original.DebtAmount
        .TimesPositiveOrThrow(positive)
        .PipeNonNull(total => original with { DebtAmount = total });

    public Result<INonNegativeFunds> Divide(Debt original, INegativeDecimal negative) => original.DebtAmount
        .Divide(negative)
        .Map(total => FundsFactory.CreateNonNegative(total, original.Currency));

    public Result<INonPositiveFunds> DivideByPositive(Debt original, IPositiveDecimal positive) => original.DebtAmount
        .DividePositive(positive)
        .Map(nonPositive => FundsFactory.CreateNonPositive(nonPositive, original.Currency));
    
    private delegate Result<Debt> DebtMathOperation(Debt first, Debt second);

    private async Task<Result<Debt>> Apply(Debt first, Debt second, DebtMathOperation sameCurrencyOperation) => first.Currency == second.Currency
        ? sameCurrencyOperation(first, second)
        : await _converter.Convert(second, first.Currency)
            .MapAsync(converted => sameCurrencyOperation(first, converted));

    private Result<Debt> SameCurrencyPlus(Debt first, Debt second) => first.DebtAmount
        .Plus(second.DebtAmount)
        .Map(total => new Debt(total, first.Currency));
    
}