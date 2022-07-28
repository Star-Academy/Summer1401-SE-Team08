using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;

public class CalculatorTester
{
    private const int MaxInt = 2147483647;
    private const int MinInt = -2147483648;
    private readonly Calculator _calculator;
    private readonly OperatorProvider _provider;
    private readonly SumOperator _sumOperator;
    private readonly SubOperator _subOperator;
    private readonly MultiplyOperator _multiplyOperator;
    private readonly DivisionOperator _divisionOperator;
    public CalculatorTester() {
        this._calculator = new Calculator();
        this._provider = new OperatorProvider();
        this._sumOperator = new SumOperator();
        this._subOperator = new SubOperator();
        this._divisionOperator = new DivisionOperator();
        this._multiplyOperator = new MultiplyOperator();
    }

    [Theory]
    [InlineData(0,1,1)]
    [InlineData(2,0,2)]
    [InlineData(-3,0,-3)]
    public void CalculatorAdditionTest(int firstOperand, int secondOperand, int expected) {
        var provider_sub = new Mock<IOperatorProvider>();
        provider_sub.Setup(x => x.GetOperator(OperatorEnum.sum)).Returns(new SumOperator());
        Calculator calculator = new Calculator(provider_sub.Object);
        int actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.sum);
        Assert.Equal(actual, expected);
    }

    [Theory]
    [InlineData(0,1,-1)]
    [InlineData(2,0,2)]
    [InlineData(-3,0,-3)]
    public void CalculatorSubTest(int firstOperand, int secondOperand, int expected) {
        var provider_sub = new Mock<IOperatorProvider>();
        provider_sub.Setup(x => x.GetOperator(OperatorEnum.sub)).Returns(new SubOperator());
        Calculator calculator = new Calculator(provider_sub.Object);
        int actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.sub);
        Assert.Equal(actual, expected);
    }


    [Theory]
    [InlineData(5,6,30)]
    [InlineData(6,5,30)]
    [InlineData(7,-8,-56)]
    public void CalculatorMultiplicationTest(int firstOperand, int secondOperand, int expected) {
        var provider_sub = new Mock<IOperatorProvider>();
        provider_sub.Setup(x => x.GetOperator(OperatorEnum.multiply)).Returns(new MultiplyOperator());
        Calculator calculator = new Calculator(provider_sub.Object);
        int actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.multiply);
        Assert.Equal(actual, expected);
    }

    [Theory]
    [InlineData(-8,7,-1)]
    [InlineData(-9,10,0)]
    [InlineData(10,-9,-1)]
    public void CalculatorDivisionTest(int firstOperand, int secondOperand, int expected) {
        var provider_sub = new Mock<IOperatorProvider>();
        provider_sub.Setup(x => x.GetOperator(OperatorEnum.division)).Returns(new DivisionOperator());
        Calculator calculator = new Calculator(provider_sub.Object);
        int actual = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.division);
        Assert.Equal(actual, expected);
    }
}
