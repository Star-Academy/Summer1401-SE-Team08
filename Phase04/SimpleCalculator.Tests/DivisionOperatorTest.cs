using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;

public class DivisionOperatorTest
{
    private readonly OperatorProvider _provider;
    private readonly DivisionOperator _divisionOperator;
    public DivisionOperatorTest() {
        _provider = new OperatorProvider();
        _divisionOperator = new DivisionOperator();
    }
    
    [Theory]
    [InlineData(OperatorEnum.Division)]
    public void DivideEnumTest(OperatorEnum @enum) {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<DivisionOperator>();
    }
    
    [Theory]
    [InlineData(0,1,0)]
    [InlineData(0,-4,0)]
    [InlineData(5,6,0)]
    [InlineData(6,5,1)]
    [InlineData(7,-8,0)]
    [InlineData(-8,7,-1)]
    [InlineData(-9,10,0)]
    [InlineData(10,-9,-1)]
    [InlineData(-11,-12,0)]
    [InlineData(-12,-11,1)]
    public void DivisionBaseTest(int firstOperand, int secondOperand, int expected) {
        // Act
        var actual = this._divisionOperator.Calculate(firstOperand, secondOperand);
        // Assert
        actual.Should().Be(expected);
    }
}