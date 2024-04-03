using Money.Decimals;
using Money.Decimals.Math;
using Results;

namespace Tests;

public class DecimalMathTests {
    private INonNegativeDecimal _oneHundred = DecimalFactory.CreateNonNegative(100).Data;
    private INonNegativeDecimal _maxValue = DecimalFactory.CreateNonNegative(decimal.MaxValue).Data;
    
    [Fact]
    public void INonNegative_Plus_Returns_NonNegative_Success_Result() {
        Result<INonNegativeDecimal> added = _oneHundred.Plus(_oneHundred);
        Assert.True(added.Succeeded);
        Assert.Equal(200, added.Data.Amount);
    }

    [Fact]
    public void INonNegative_Plus_Returns_Failed_Result_On_Overflow() {
        Result<INonNegativeDecimal> added = _maxValue.Plus(_maxValue);
        Assert.True(added.Failed);
        Assert.True(added.Error is ExceptionWrapper);
    }

    [Fact]
    public void INonNegative_PlusOrThrow_Correct_Math() {
        INonNegativeDecimal added = _oneHundred.PlusOrThrow(_oneHundred);
        Assert.Equal(200, added.Amount);
    }

    [Fact]
    public void INonNegative_PlusOrThrow_Throws_On_Overflow() {
        Assert.Throws<OverflowException>(() => _maxValue.PlusOrThrow(_maxValue));
    }
}