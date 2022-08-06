using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;

public class MultiplyOperatorTest
{
    private readonly MultiplyOperator _multiplyOperator;
    public MultiplyOperatorTest() {
        // Arrange
        _multiplyOperator = new MultiplyOperator();
    }
    
    
    [Theory]
    [InlineData(0,1,0)]
    [InlineData(-11,-12,132)]
    [InlineData(-12,-11,132)]
    public void MultiplicationBaseTest(int firstOperand, int secondOperand, int expected) {
        // Act
        var actual = _multiplyOperator.Calculate(firstOperand, secondOperand);
        // Assert
        actual.Should().Be(expected);
    }
    
    
}