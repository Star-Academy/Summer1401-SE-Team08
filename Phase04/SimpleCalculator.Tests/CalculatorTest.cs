using FluentAssertions;
using Phase04.SimpleCalculator.Business;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.Abstraction;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;


namespace Phase04.SimpleCalculator.Tests;

public class CalculatorTester
{

    [Theory]
    [InlineData(0,1,1)]
    public void CalculatorAdditionTest(int firstOperand, int secondOperand, int expected) {
        // Arrange
        var providerSub = new Mock<IOperatorProvider>();
        providerSub.Setup(x => x.GetOperator(OperatorEnum.Sum)).Returns(new SumOperator());
        var calculator = new Calculator(providerSub.Object);
        // Act
        var actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.Sum);
        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(0,1,-1)]
    [InlineData(2,0,2)]
    [InlineData(-3,0,-3)]
    public void CalculatorSubTest(int firstOperand, int secondOperand, int expected) {
        // Arrange
        var providerSub = new Mock<IOperatorProvider>();
        providerSub.Setup(x => x.GetOperator(OperatorEnum.Sub)).Returns(new SubOperator());
        var calculator = new Calculator(providerSub.Object);
        // Act
        var actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.Sub);
        // Assert
        actual.Should().Be(expected);
    }


    [Theory]
    [InlineData(5,6,30)]
    [InlineData(6,5,30)]
    [InlineData(7,-8,-56)]
    public void CalculatorMultiplicationTest(int firstOperand, int secondOperand, int expected) {
        // Arrange
        var providerSub = new Mock<IOperatorProvider>();
        providerSub.Setup(x => x.GetOperator(OperatorEnum.Multiply)).Returns(new MultiplyOperator());
        var calculator = new Calculator(providerSub.Object);
        // Act
        var actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.Multiply);
        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(-8,7,-1)]
    [InlineData(-9,10,0)]
    [InlineData(10,-9,-1)]
    public void CalculatorDivisionTest(int firstOperand, int secondOperand, int expected) {
        // Arrange 
        var providerSub = new Mock<IOperatorProvider>();
        providerSub.Setup(x => x.GetOperator(OperatorEnum.Division)).Returns(new DivisionOperator());
        var calculator = new Calculator(providerSub.Object);
        // Act
        var actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.Division);
        // Assert
        actual.Should().Be(expected);
    }
}
