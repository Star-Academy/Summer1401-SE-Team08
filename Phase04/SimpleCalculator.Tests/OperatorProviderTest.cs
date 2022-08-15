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
        _provider = new OperatorProvider();
    }

    [Theory]
    [InlineData(OperatorEnum.Division)]
    public void OperatorProviderTest_ShouldReturnDivisionOperator_WhenGivenDivisonEnum(OperatorEnum @enum)
    {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<DivisionOperator>();
    }
    [Theory]
    [InlineData(OperatorEnum.Multiply)]
    public void OperatorProviderTest_ShouldReturnMultiplicationOperator_WhenGivenMultiplyEnum(OperatorEnum @enum)
    {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<MultiplyOperator>();
    }

    [Theory]
    [InlineData(OperatorEnum.Sub)]
    public void OperatorProviderTest_ShouldReturnMSubOperator_WhenGivenSubEnum(OperatorEnum @enum)
    {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<SubOperator>();
    }

    [Theory]
    [InlineData(OperatorEnum.Sum)]
    public void OperatorProviderTest_ShouldReturnMSumOperator_WhenGivenSumEnum(OperatorEnum @enum)
    {
        // Act
        var actual = _provider.GetOperator(@enum);
        // Assert
        actual.Should().BeOfType<SumOperator>();
    }
}