using System.Security.Cryptography;
using Results;

namespace Tests;

public class DecimalTests
{
    private const decimal DecimalHundred = 100M;
    private const decimal DecimalTwo = 2M;
    private static IPositiveDecimal OneHundred => PositiveDecimal.Create(DecimalHundred).Data;
    private static IPositiveDecimal Two => PositiveDecimal.Create(DecimalTwo).Data;

    [Fact]
    public void Positive_Decimal_Cannot_Be_Created_With_Negative_Decimal()
    {
        Result<PositiveDecimal> positiveDecimalResult = PositiveDecimal.Create(-200M);
        Assert.True(positiveDecimalResult.Failed);
    }

    [Fact]
    public void PositiveDecimal_Cannot_Be_Created_With_Zero()
    {
        Result<PositiveDecimal> zeroResult = PositiveDecimal.Create(0M);
        Assert.True(zeroResult.Failed);
    }

    [Fact]
    public void NegativeDecimal_Cannot_Be_Created_With_Positive_Decimal()
    {
        Result<NegativeDecimal> negativeResult = NegativeDecimal.Create(200M);
        Assert.True(negativeResult.Failed);
    }

    [Fact]
    public void NegativeDecimal_Cannot_Be_Created_With_Zero()
    {
        Result<NegativeDecimal> negativeResult = NegativeDecimal.Create(0M);
        Assert.True(negativeResult.Failed);
    }

    [Fact]
    public void PositiveDecimal_Times_Correctly_Multiplies()
    {
        IPositiveDecimal multiplied = OneHundred.Times(Two);
        decimal multipliedDecimal = DecimalHundred * DecimalTwo;
        Assert.Equal(multipliedDecimal, multiplied.Amount);
    }

    [Fact]
    public void PositiveDecimal_DivideBy_Correctly_Divides()
    {
        IPositiveDecimal divided = OneHundred.DivideBy(Two);
        decimal dividedDecimal = DecimalHundred / DecimalTwo;
        Assert.Equal(dividedDecimal, divided.Amount);
    }

    [Fact]
    public void PositiveDecimal_Plus_Correctly_Adds()
    {
        IPositiveDecimal added = OneHundred.Plus(Two);
        decimal addedDecimal = DecimalHundred + DecimalTwo;
        Assert.Equal(addedDecimal, added.Amount);
    }
}