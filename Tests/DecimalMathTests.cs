using MoneyManagement.Decimals;
using MoneyManagement.Decimals.Math;
using ResultAndOption.Errors;
using ResultAndOption.Results;

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

    [Fact]
    public void INonNegative_Times_Returns_INonNegative_Success_Result() {
        Result<INonNegativeDecimal> multiplied = _oneHundred.Times(_oneHundred);
        Assert.True(multiplied.Succeeded);
    }

    [Fact]
    public void INonNegative_Times_Returns_Failed_Result_On_Overflow() {
        Result<INonNegativeDecimal> multiplied = _maxValue.Times(_maxValue);
        Assert.True(multiplied.Failed);
        Assert.True(multiplied.Error is ExceptionWrapper);
    }

    [Fact]
    public void INonNegative_TimesOrThrow_Returns_INonNegative_Value() {
        INonNegativeDecimal multiplied = _oneHundred.TimesOrThrow(_oneHundred);
        decimal total = _oneHundred.Amount * _oneHundred.Amount;
        Assert.Equal(total, multiplied.Amount);
    }

    [Fact]
    public void INonNegative_TimesOrThrow_Throws_Overflow_Exception() {
        Assert.Throws<OverflowException>(() => _maxValue.TimesOrThrow(_maxValue));
    }

    [Fact]
    public void INonNegative_DivideBy_Returns_INonNegative_Success_Result() {
        Result<INonNegativeDecimal> divided = _oneHundred.DivideBy(_oneHundred);
        Assert.True(divided.Succeeded);
    }

    [Fact]
    public void INonNegative_DivideBy_Returns_Failed_Result_When_Dividing_By_Zero() {
        Result<INonNegativeDecimal> divided = _oneHundred.DivideBy(new ZeroDecimal());
        Assert.True(divided.Failed);
    }

    [Fact]
    public void INonNegative_DivideBy_Returns_Failed_Result_On_Overflow() {
        INonNegativeDecimal tiny = DecimalFactory.CreateNonNegative(0.0000000000000000000001M).Data;
        Result<INonNegativeDecimal> divided = _maxValue.DivideBy(tiny);
        Assert.True(divided.Failed);
    }
}