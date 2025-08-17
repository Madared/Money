using System.Runtime.CompilerServices;
using MoneyManagement.Decimals.Math;
using MoneyManagement.Currencies.Converters;
using MoneyManagement.Decimals;
using ResultAndOption;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;
using ResultAndOption.Results.GenericResultExtensions.Async;

namespace MoneyManagement.Funds.Math;

public sealed class DefaultDebtMath {
    private readonly IDebtCurrencyConverter _converter;
    private readonly IMoneyCurrencyConverter _moneyConverter;
    private readonly IFundsFactory _factory;

    public DefaultDebtMath(IDebtCurrencyConverter converter, IMoneyCurrencyConverter moneyConverter) {
        _converter = converter;
        _moneyConverter = moneyConverter;
    }
    public Task<Result<Debt>> Plus(Debt first, Debt second) => Apply(first, second, SameCurrencyPlus);

    public async Task<Result<INonPositiveFunds>> ReduceDebt(Debt original, Money amountToReduce) {
        if (original.Currency == amountToReduce.Currency) {
            decimal reduced = original.DebtAmount - amountToReduce.CashAmount;
            return NegativeDecimal
                .Create(reduced)
                .Map<NegativeDecimal, INonPositiveFunds>(negative => _factory.Debt(negative, original.Currency));
        }
        return await _moneyConverter
            .Convert(amountToReduce, original.Currency)
            .MapAsync(converted => original.DebtAmount.Amount - converted.CashAmount.Amount)
            .MapAsync(total => NegativeDecimal.Create(total))
            .MapAsync<NegativeDecimal, INonPositiveFunds>(negative => _factory.Debt(negative, original.Currency));
    }

    public Result<Debt> Multiply(Debt original, IPositiveDecimal positive) => original.DebtAmount
        .TimesPositive(positive)
        .Map(negativeAmount => new NegativeDecimal(negativeAmount))
        .Map(multiplied => _factory.Debt(multiplied, original.Currency));

    public Debt MutltiplyOrThrow(Debt original, IPositiveDecimal positive) => original.DebtAmount
        .TimesPositiveOrThrow(positive)
        .Pipe(negativeAmount => new NegativeDecimal(negativeAmount))
        .Pipe(total => _factory.Debt(total, original.Currency));

    public Result<INonNegativeFunds> Divide(Debt original, INegativeDecimal negative) => original.DebtAmount
        .Divide(negative)
        .Map(n => PositiveDecimal.Create(n.Amount))
        .Map<PositiveDecimal, INonNegativeFunds>(total => _factory.Money(total, original.Currency));

    public Result<INonPositiveFunds> DivideByPositive(Debt original, IPositiveDecimal positive) => original.DebtAmount
        .DividePositive(positive)
        .Map(value => NegativeDecimal.Create(value.Amount))
        .Map<NegativeDecimal, INonPositiveFunds>(nonPositive => _factory.Debt(nonPositive, original.Currency));
    
    public Result<Debt> Times(Debt debt, IPositiveDecimal multiplier) => debt.DebtAmount
        .TimesPositive(multiplier)
        .Map(negativeAmount => new NegativeDecimal(negativeAmount))
        .Map(total => _factory.Debt(total, debt.Currency));

    public Result<INonPositiveFunds> DivideBy(Debt debt, IPositiveDecimal dividend) => debt.DebtAmount
        .DividePositive(dividend)
        .Map(value => NegativeDecimal.Create(value.Amount))
        .Map<NegativeDecimal, INonPositiveFunds>(total => _factory.Debt(total, debt.Currency));
    private delegate Result<Debt> DebtMathOperation(Debt first, Debt second);

    private async Task<Result<Debt>> Apply(Debt first, Debt second, DebtMathOperation sameCurrencyOperation) => first.Currency == second.Currency
        ? sameCurrencyOperation(first, second)
        : await _converter.Convert(second, first.Currency)
            .MapAsync(converted => sameCurrencyOperation(first, converted));

    private Result<Debt> SameCurrencyPlus(Debt first, Debt second) => first.DebtAmount
        .Plus(second.DebtAmount)
        .Map(negativeAmount => new NegativeDecimal(negativeAmount))
        .Map(total => _factory.Debt(total, first.Currency));
    
}