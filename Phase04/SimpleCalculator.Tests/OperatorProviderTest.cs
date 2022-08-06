using FluentAssertions;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Tests;


public class OperatorProviderTest
{
    private readonly OperatorProvider _provider;

    public OperatorProviderTest()
    {
        // Arrange
        _provider = new OperatorProvider();
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
    [InlineData(OperatorEnum.Multiply)]
    public void MultiplyEnumTest(OperatorEnum @enum) {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<MultiplyOperator>();
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
    [InlineData(OperatorEnum.Sum)]
    public void SumEnumTet(OperatorEnum @enum) {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<SumOperator>();
    }
    
    [Theory]
    [InlineData(null)]
    public void NotSupportedExceptionTest(OperatorEnum @enum) {
        // Act & Assert
        _provider.Invoking(y => y.GetOperator(@enum))
            .Should().Throw<Exception>();
    }
    
    
}