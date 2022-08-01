using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;

public class SumOperatorTest
{
    private readonly OperatorProvider _provider;
    private readonly SumOperator _sumOperator;
    public SumOperatorTest() {
        _provider = new OperatorProvider();
        _sumOperator = new SumOperator();
    }
    
    [Theory]
    [InlineData(OperatorEnum.Sum)]
    public void SumEnumTet(OperatorEnum @enum) {
        // Act
        var actual = this._provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<SumOperator>();
    }
    
    [Theory]
    [InlineData(0,1,1)]
    [InlineData(2,0,2)]
    [InlineData(-3,0,-3)]
    [InlineData(0,-4,-4)]
    [InlineData(5,6,11)]
    [InlineData(6,5,11)]
    [InlineData(7,-8,-1)]
    [InlineData(-8,7,-1)]
    [InlineData(-9,10,1)]
    [InlineData(10,-9,1)]
    [InlineData(-11,-12,-23)]
    [InlineData(-12,-11,-23)]
    public void AdditionBaseTest(int firstOperand, int secondOperand, int expected)
    {
        // Act
        var actual = _sumOperator.Calculate(firstOperand, secondOperand);
        // Assert
        actual.Should().Be(expected);
    }
}