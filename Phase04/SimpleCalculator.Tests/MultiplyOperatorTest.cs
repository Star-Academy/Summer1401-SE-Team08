using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;

public class MultiplyOperatorTest
{
    private readonly OperatorProvider _provider;
    private readonly MultiplyOperator _multiplyOperator;
    public MultiplyOperatorTest() {
        _provider = new OperatorProvider();
        _multiplyOperator = new MultiplyOperator();
    }
    
    [Theory]
    [InlineData(OperatorEnum.Multiply)]
    public void MultiplyEnumTest(OperatorEnum @enum) {
        // Act
        var actual = this._provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<MultiplyOperator>();
    }
    
    [Theory]
    [InlineData(0,1,0)]
    [InlineData(2,0,0)]
    [InlineData(-3,0,0)]
    [InlineData(0,-4,0)]
    [InlineData(5,6,30)]
    [InlineData(6,5,30)]
    [InlineData(7,-8,-56)]
    [InlineData(-8,7,-56)]
    [InlineData(-9,10,-90)]
    [InlineData(10,-9,-90)]
    [InlineData(-11,-12,132)]
    [InlineData(-12,-11,132)]
    public void MultiplicationBaseTest(int firstOperand, int secondOperand, int expected) {
        // Act
        var actual = this._multiplyOperator.Calculate(firstOperand, secondOperand);
        // Assert
        actual.Should().Be(expected);
    }
    
    
}