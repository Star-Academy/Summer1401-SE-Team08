using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;
public class ExceptionTester {
    
    private readonly OperatorProvider _provider;
    private readonly SubOperator _subOperator;
    private readonly MultiplyOperator _multiplyOperator;
    private readonly DivisionOperator _divisionOperator;


  public ExceptionTester()
    {
        _provider = new OperatorProvider();
        _subOperator = new SubOperator();
        _divisionOperator = new DivisionOperator();
        _multiplyOperator = new MultiplyOperator();
    }

    [Theory]
    [InlineData(null)]
    public void NotSupportedExceptionTest(OperatorEnum @enum) {
        // Act & Assert
        _provider.Invoking(y => y.GetOperator(@enum))
            .Should().Throw<Exception>();
    }

    [Theory]
    [InlineData(Int32.MaxValue, 1)]
    [InlineData(Int32.MinValue, -1)]
    public void AdditionOverflowTest(int firstOperand, int secondOperand)
    {   
        // Act & Assert
        _subOperator.Invoking(y => y.Calculate(firstOperand, secondOperand))
            .Should().Throw<Exception>();

    }

    [Theory]
    [InlineData(Int32.MaxValue, -1)]
    [InlineData(Int32.MinValue, 1)]
    public void SubtractionOverflowTest(int firstOperand, int secondOperand)
    {
        // Act & Assert
        _subOperator.Invoking(y => y.Calculate(firstOperand, secondOperand))
            .Should().Throw<Exception>();
    }

    [Theory]
    [InlineData(Int32.MaxValue,2)]
    [InlineData(Int32.MaxValue,-2)]
    [InlineData(Int32.MinValue,2)]
    [InlineData(Int32.MinValue,-2)]
    public void MultiplicationOverflowTest(int firstOperand, int secondOperand) {
        // Act & Assert
        _multiplyOperator.Invoking(y => y.Calculate(firstOperand, secondOperand))
            .Should().Throw<Exception>();
    }

    [Theory]
    [InlineData(1,0)]
    public void DivisionByZeroTest(int firstOperand, int secondOperand) {
        // Act & Assert
        _divisionOperator.Invoking(y => y.Calculate(firstOperand, secondOperand))
            .Should().Throw<Exception>();
    }
}