namespace Tester;

using SimpleCalculator.Business.OperatorBusiness.Operators;
public class CalculatorTester
{
    public const int MaxInt = 2147483647;
    public const int MinInt = -2147483648;

    [Theory]
    [InlineData(MaxInt, 1)]
    [InlineData(MinInt, -1)]
    public void OverflowTest(int first, int second)
    {
        //arrange
        var sumOperator = new SumOperator();
        //act
        Action act = () => sumOperator.Calculate(first, second);
        //assert
        Assert.Throws<Exception>(act);
    }
}