using System.Security.Cryptography;
using Money.Decimals;
using Results;

namespace Tests;

public class DecimalTests {
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
        IPositiveDecimal divided = OneHundred.DivideBy(Two).Data;
        decimal dividedDecimal = DecimalHundred / DecimalTwo;
        Assert.Equal(dividedDecimal, divided.Amount);
    }

    [Fact]
    public void PositiveDecimal_MinValue_DivideBy_MaxValue_Gives_Failed_Result() {
        IPositiveDecimal min = PositiveDecimal.Create(0.0000000001M).Data;
        IPositiveDecimal max = PositiveDecimal.Create(decimal.MaxValue).Data;
        Result<IPositiveDecimal> divided = min.DivideBy(max);
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
}