using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;


public class ExceptionTester {


  private const int MaxInt = 2147483647;
    private const int MinInt = -2147483648;
    private readonly Calculator _calculator;
    private readonly OperatorProvider _provider;
    private readonly SumOperator _sumOperator;
    private readonly SubOperator _subOperator;
    private readonly MultiplyOperator _multiplyOperator;
    private readonly DivisionOperator _divisionOperator;


  public ExceptionTester()
    {
        this._calculator = new Calculator();
        this._provider = new OperatorProvider();
        this._sumOperator = new SumOperator();
        this._subOperator = new SubOperator();
        this._divisionOperator = new DivisionOperator();
        this._multiplyOperator = new MultiplyOperator();
    }

    [Theory]
    [InlineData(null)]
    public void NotSupportedExceptionTest(OperatorEnum @enum) {
        Action act = () => _provider.GetOperator(@enum);
        Assert.Throws<NotSupportedException>(act);
    }

    [Theory]
    [InlineData(MaxInt, 1)]
    [InlineData(MinInt, -1)]
    public void AdditionOverflowTest(int firstOperand, int secondOperand)
    {   
        Action act = () => this._sumOperator.Calculate(firstOperand, secondOperand);
        Assert.Throws<Exception>(act);
    }

    [Theory]
    [InlineData(MaxInt, -1)]
    [InlineData(MinInt, 1)]
    public void SubtractionOverflowTest(int firstOperand, int secondOperand)
    {   
        Action act = () => this._subOperator.Calculate(firstOperand, secondOperand);
        Assert.Throws<Exception>(act);
    }

    [Theory]
    [InlineData(MaxInt,2)]
    [InlineData(MaxInt,-2)]
    [InlineData(MinInt,2)]
    [InlineData(MinInt,-2)]
    public void MultiplicationOverflowTest(int firstOperand, int secondOperand) {
        Action act = () => this._multiplyOperator.Calculate(firstOperand, secondOperand);
        Assert.Throws<Exception>(act);
    }

    [Theory]
    [InlineData(MaxInt,0)]
    [InlineData(MinInt,0)]
    public void DivisionByZeroTest(int firstOperand, int secondOperand) {
        Action act = () => this._divisionOperator.Calculate(firstOperand, secondOperand);
        Assert.Throws<DivideByZeroException>(act);
    }
}