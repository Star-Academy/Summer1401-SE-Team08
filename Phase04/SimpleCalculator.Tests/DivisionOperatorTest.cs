using FluentAssertions;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;

public class DivisionOperatorTest
{
    private readonly DivisionOperator _divisionOperator;
    public DivisionOperatorTest() {
        // Arrange
        _divisionOperator = new DivisionOperator();
    }
    
    
    [Theory]
    [InlineData(10,-9,-1)]
    [InlineData(-11,-12,0)]
    [InlineData(-12,-11,1)]
    public void DivisionBaseTest(int firstOperand, int secondOperand, int expected) {
        // Act
        var actual = _divisionOperator.Calculate(firstOperand, secondOperand);
        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1,0)]
    public void DivisionByZeroTest(int firstOperand, int secondOperand) {
        // Act & Assert
        _divisionOperator.Invoking(y => y.Calculate(firstOperand, secondOperand))
            .Should().Throw<Exception>();
    }
}