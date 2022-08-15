using FluentAssertions;
using Phase04.SimpleCalculator.Business;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.Abstraction;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;


namespace Phase04.SimpleCalculator.Tests;

public class CalculatorTester
{
    [Fact]
    public void CalculatorAdditionTest_ShouldReturnSumOfTwoNumbers_WhenGivenTheTwoNumbers()
    {
        // Arrange
        const int firstParam = 1;
        const int secondParam = 23;
        const int expected = 24;
        var sumOperator = Substitute.For<IOperator>();
        sumOperator.Calculate(firstParam, secondParam).Returns(expected);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Sum).Returns(sumOperator);
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(firstParam, secondParam, OperatorEnum.Sum);
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
    public void CalculatorSubTest_ShouldReturnDifferenceOfTwoNumbers_WhenGivenTheTwoNumbers()
    {
        // Arrange
        const int firstParam = 30;
        const int secondParam = 2;
        const int expected = 28;
        var subOperator = Substitute.For<IOperator>();
        subOperator.Calculate(firstParam, secondParam).Returns(expected);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Sub).Returns(subOperator);
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(firstParam, secondParam, OperatorEnum.Sub);
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
    public void CalculatorMultiplicationTest_ShouldReturnProductOfTwoNumbers_WhenGivenTheTwoNumbers()
    {
        // Arrange
        const int firstParam = 30;
        const int secondParam = 2;
        const int expected = 60;
        var multiplicationOperator = Substitute.For<IOperator>();
        multiplicationOperator.Calculate(firstParam, secondParam).Returns(expected);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Multiply).Returns(multiplicationOperator);
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(firstParam, secondParam, OperatorEnum.Multiply);
        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void CalculatorDivisionTest_ShouldReturnQuotientOfTwoNumbers_WhenGivenTheTwoNumbers()
    {
        // Arrange
        const int firstParam = 30;
        const int secondParam = 2;
        const int expected = 15;
        var divisionOperator = Substitute.For<IOperator>();
        divisionOperator.Calculate(firstParam, secondParam).Returns(expected);
        var provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.Division).Returns(divisionOperator);
        // Act 
        var calculator = new Calculator(provider);
        var actual = calculator.Calculate(firstParam, secondParam, OperatorEnum.Division);
        // Assert
        actual.Should().Be(expected);
    }
}