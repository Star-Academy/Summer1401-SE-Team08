using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;

public class SumOperatorTest
{
    private readonly SumOperator _sumOperator;
    public SumOperatorTest() {
        // Arrange
        _sumOperator = new SumOperator();
    }
    
    [Theory]
    [InlineData(0,1,1)]
    [InlineData(2,0,2)]
    [InlineData(-3,0,-3)]
    public void AdditionBaseTest(int firstOperand, int secondOperand, int expected)
    {
        // Act
        var actual = _sumOperator.Calculate(firstOperand, secondOperand);
        // Assert
        actual.Should().Be(expected);
    }
}