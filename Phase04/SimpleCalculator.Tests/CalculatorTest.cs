using FluentAssertions;
using Phase04.SimpleCalculator.Business;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.Abstraction;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;


namespace Phase04.SimpleCalculator.Tests;

public class CalculatorTester
{

    [Fact]
    public void CalculatorAdditionTest()
    {
        // Arrange
        var sumOperator = Substitute.For<IOperator>();
        sumOperator.Calculate(1, 23).Returns(24);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Sum).Returns(sumOperator);
        const int expected = 24;
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(1, 23, OperatorEnum.Sum);
        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void CalculatorSubTest() {
        // Arrange
        var subOperator = Substitute.For<IOperator>();
        subOperator.Calculate(30, 2).Returns(28);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Sub).Returns(subOperator);
        const int expected = 28;
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(30, 2, OperatorEnum.Sub);
        // Assert
        actual.Should().Be(expected);
    }


    [Fact]
    public void CalculatorMultiplicationTest() {
        // Arrange
        var multiplicationOperator = Substitute.For<IOperator>();
        multiplicationOperator.Calculate(30, 2).Returns(60);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Multiply).Returns(multiplicationOperator);
        const int expected = 60;
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(30, 2, OperatorEnum.Multiply);
        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void CalculatorDivisionTest() {
        // Arrange
        var divisionOperator = Substitute.For<IOperator>();
        divisionOperator.Calculate(30, 2).Returns(15);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Division).Returns(divisionOperator);
        const int expected = 15;
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(30, 2, OperatorEnum.Division);
        // Assert
        actual.Should().Be(expected);
    }
}
