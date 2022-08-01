using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;

public class SubOperatorTest
{
    private readonly OperatorProvider _provider;
    private readonly SubOperator _subOperator;
    public SubOperatorTest() {
        _provider = new OperatorProvider();
        _subOperator = new SubOperator();
    }
    
    
    [Theory]
    [InlineData(OperatorEnum.Sub)]
    public void SubEnumTest(OperatorEnum @enum) {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<SubOperator>();
    }
    
    [Theory]
    [InlineData(0,1,-1)]
    [InlineData(2,0,2)]
    [InlineData(-3,0,-3)]
    [InlineData(0,-4,4)]
    [InlineData(5,6,-1)]
    [InlineData(6,5,1)]
    [InlineData(7,-8,15)]
    [InlineData(-8,7,-15)]
    [InlineData(-9,10,-19)]
    [InlineData(10,-9,19)]
    [InlineData(-11,-12,1)]
    [InlineData(-12,-11,-1)]
    public void SubtractionBaseTest(int firstOperand, int secondOperand, int expected)
    {
        // Act
        var actual = _subOperator.Calculate(firstOperand, secondOperand);
        // Assert
        actual.Should().Be(expected);
    }
}