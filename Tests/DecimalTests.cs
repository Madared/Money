using System.Security.Cryptography;
using MoneyManagement.Decimals;
using MoneyManagement.Decimals.Math;
using Results;
using Xunit.Abstractions;

namespace Tests;

public class DecimalTests {
    private readonly ITestOutputHelper _testOutputHelper;

    public DecimalTests(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
    }

    private const decimal DecimalHundred = 100M;
    private const decimal DecimalTwo = 2M;
    private static IPositiveDecimal OneHundred => PositiveDecimal.Create(DecimalHundred).Data;
    private static IPositiveDecimal Two => PositiveDecimal.Create(DecimalTwo).Data;

    [Fact]
    public void Positive_Decimal_Cannot_Be_Created_With_Negative_Decimal() {
        Result<PositiveDecimal> positiveDecimalResult = PositiveDecimal.Create(-200M);
        Assert.True(positiveDecimalResult.Failed);
    }

    [Fact]
    public void PositiveDecimal_Cannot_Be_Created_With_Zero() {
        Result<PositiveDecimal> zeroResult = PositiveDecimal.Create(0M);
        Assert.True(zeroResult.Failed);
    }

    [Fact]
    public void NegativeDecimal_Cannot_Be_Created_With_Positive_Decimal() {
        Result<NegativeDecimal> negativeResult = NegativeDecimal.Create(200M);
        Assert.True(negativeResult.Failed);
    }

    [Fact]
    public void NegativeDecimal_Cannot_Be_Created_With_Zero() {
        Result<NegativeDecimal> negativeResult = NegativeDecimal.Create(0M);
        Assert.True(negativeResult.Failed);
    }

    [Fact]
    public void PositiveDecimal_Times_Correctly_Multiplies() {
        Result<IPositiveDecimal> multiplied = OneHundred.Times(Two);
        decimal multipliedDecimal = DecimalHundred * DecimalTwo;
        Assert.True(multiplied.Succeeded);
        Assert.Equal(multipliedDecimal, multiplied.Data.Amount);
    }

    [Fact]
    public void PositiveDecimal_DivideBy_Correctly_Divides() {
        IPositiveDecimal divided = OneHundred.DivideBy(Two).Data.AsPositive().Data;
        decimal dividedDecimal = DecimalHundred / DecimalTwo;
        Assert.Equal(dividedDecimal, divided.Amount);
    }

    [Fact]
    public void PositiveDecimal_MinValue_DivideBy_MaxValue_Gives_Failed_Result() {
        IPositiveDecimal min = PositiveDecimal.Create(0.0000000001M).Data;
        IPositiveDecimal max = PositiveDecimal.Create(decimal.MaxValue).Data;
        Result<IPositiveDecimal> divided = min.DivideBy(max).Data.AsPositive();
        Assert.True(divided.Failed);
    }

    [Fact]
    public void PositiveDecimal_Plus_Correctly_Adds() {
        Result<IPositiveDecimal> added = OneHundred.Plus(Two);
        decimal addedDecimal = DecimalHundred + DecimalTwo;
        Assert.True(added.Succeeded);
        Assert.Equal(addedDecimal, added.Data.Amount);
    }

    [Fact]
    public void PositiveDecimal_Max_Value_Plus_Fails() {
        IPositiveDecimal max = PositiveDecimal.Create(decimal.MaxValue).Data;
        Result<IPositiveDecimal> added = max.Plus(max);
        Assert.True(added.Failed);
    }

    [Fact]
    public void PositiveDecimal_Max_Value_Times_Throws_Overflow() {
        IPositiveDecimal max = PositiveDecimal.Create(decimal.MaxValue).Data;
        Result<IPositiveDecimal> multiplied = max.Times(max);
        Assert.True(multiplied.Failed);
    }

    [Fact]
    public void NegativeDecimal_Times_Positive_Returns_NegativeDecimal() {
        INegativeDecimal negative = NegativeDecimal.Create(-1000).Data;
        IPositiveDecimal positive = PositiveDecimal.Create(1000).Data;
        Result<INegativeDecimal> multiplied = negative.TimesPositive(positive);
        Assert.True(multiplied.Succeeded);
        Assert.Equal(-1000000, multiplied.Data.Amount);
    }

    [Fact]
    public void NegativeDecimal_Times_NegativeDecimal_Returns_PositiveDecimal() {
        INegativeDecimal negativeOne = NegativeDecimal.Create(-1000).Data;
        INegativeDecimal negativeTwo = NegativeDecimal.Create(-1000).Data;
        Result<IPositiveDecimal> multiplied = negativeOne.Times(negativeTwo);
        Assert.True(multiplied.Succeeded);
        Assert.Equal(1000000, multiplied.Data.Amount);
    }

    [Fact]
    public void PositiveDecimal_Times_With_Max_Values_Returns_Failed_Result_Wrapping_OverflowException() {
        IPositiveDecimal maxDecimal = PositiveDecimal.Create(decimal.MaxValue).Data;
        Result<IPositiveDecimal> multipliedResult = maxDecimal.Times(maxDecimal);
        Assert.True(multipliedResult.Failed);
        Assert.True(multipliedResult.Error is ExceptionWrapper);
    }

    [Fact]
    public void PositiveDecimal_DivideBy_Small_Value_By_Max_Value_Returns_Zero() {
        decimal small = 0.0000000001M;
        IPositiveDecimal positiveSmall = PositiveDecimal.Create(small).Data;
        IPositiveDecimal positiveMax = PositiveDecimal.Create(decimal.MaxValue).Data;
        Result<INonNegativeDecimal> nonNegativeDecimal = positiveSmall.DivideBy(positiveMax);
        Assert.True(nonNegativeDecimal.Succeeded);
        Assert.True(nonNegativeDecimal.Data.AsZero().Succeeded);
    }

    [Fact]
    public void PositiveDecimal_Plus_With_Max_Values_Returns_Failed_Wrapping_OverflowException() {
        IPositiveDecimal maxPositive = PositiveDecimal.Create(decimal.MaxValue).Data;
        Result<IPositiveDecimal> addedResult = maxPositive.Plus(maxPositive);
        Assert.True(addedResult.Failed);
        Assert.True(addedResult.Error is ExceptionWrapper);
    }

    [Fact]
    public void AsZero_Returns_ZeroDecimal_Success_Result() {
        INonNegativeDecimal zeroDecimal = new ZeroDecimal();
        Result<ZeroDecimal> asZero = zeroDecimal.AsZero();
        Assert.True(asZero.Succeeded);
        Assert.Equal(zeroDecimal, asZero.Data);
    }

    [Fact]
    public void AsZero_Returns_Failed_Result_From_NegativeDecimal() {
        INonPositiveDecimal negativeDecimal = NegativeDecimal.Create(-100).Data;
        Result<ZeroDecimal> asZero = negativeDecimal.AsZero();
        Assert.True(asZero.Failed);
    }

    [Fact]
    public void AsNegative_Returns_NegativeDecimal_Success_Result() {
        INonPositiveDecimal negativeDecimal = NegativeDecimal.Create(-100).Data;
        Result<INegativeDecimal> asNegative = negativeDecimal.AsNegative();
        Assert.True(asNegative.Succeeded);
        Assert.Equal(negativeDecimal, asNegative.Data);
    }

    [Fact]
    public void AsPositive_Returns_IPositiveDecimal_Success_Result() {
        INonNegativeDecimal positiveDecimal = PositiveDecimal.Create(100).Data;
        Result<IPositiveDecimal> asPositive = positiveDecimal.AsPositive();
        Assert.True(asPositive.Succeeded);
        Assert.Equal(positiveDecimal, asPositive.Data);
    }

    [Fact]
    public void AsZero_Returns_Failed_Result_From_PositiveDecimal() {
        INonNegativeDecimal positiveDecimal = PositiveDecimal.Create(100).Data;
        Result<ZeroDecimal> asZero = positiveDecimal.AsZero();
        Assert.True(asZero.Failed);
    }

    [Fact]
    public void DecimalFactory_CreateNonNegative_Creates_Successfully() {
        decimal positiveValue = 100;
        Result<INonNegativeDecimal> nonNegativeDecimal = DecimalFactory.CreateNonNegative(positiveValue);
        Assert.True(nonNegativeDecimal.Succeeded);
        Assert.Equal(positiveValue, nonNegativeDecimal.Data.Amount);
    }

    [Fact]
    public void DecimalFactory_CreateNonNegative_Returns_Failed_Result_On_Negative_Value() {
        Result<INonNegativeDecimal> nonNegativeValue = DecimalFactory.CreateNonNegative(-100);
        Assert.True(nonNegativeValue.Failed);
    }

    [Fact]
    public void DecimalFactory_Successfully_Creates_Zero() {
        ZeroDecimal zero = new ZeroDecimal();
        Result<INonNegativeDecimal> nonNegative = DecimalFactory.CreateNonNegative(0);
        Result<INonPositiveDecimal> nonPositive = DecimalFactory.CreateNonPositive(0);
        Assert.True(nonNegative.Succeeded);
        Assert.True(nonPositive.Succeeded);
        Assert.Equal(zero, nonNegative.Data);
        Assert.Equal(zero, nonPositive.Data);
    }

    [Fact]
    public void Decimal_Factory_CreateNonPositive_Creates_Successfully() {
        decimal negativeValue = -100;
        Result<INonPositiveDecimal> nonPositive = DecimalFactory.CreateNonPositive(negativeValue);
        Assert.True(nonPositive.Succeeded);
        Assert.Equal(negativeValue, nonPositive.Data.Amount);
    }

    [Fact]
    public void Decimal_Factory_CreateNonPositive_Returns_Failed_Result_On_Positive_Value() {
        Result<INonPositiveDecimal> nonPositive = DecimalFactory.CreateNonPositive(100);
        Assert.True(nonPositive.Failed);
    }
}