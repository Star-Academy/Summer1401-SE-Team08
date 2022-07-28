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
        //arrange
        this._calculator = new Calculator();
        this._provider = new OperatorProvider();
        this._sumOperator = new SumOperator();
        this._subOperator = new SubOperator();
        this._divisionOperator = new DivisionOperator();
        this._multiplyOperator = new MultiplyOperator();
    }

    [Theory]
    [InlineData(OperatorEnum.sum)]
    public void SumEnumTet(OperatorEnum @enum) {
        var actual = this._provider.GetOperator(@enum);
        Assert.IsType<SumOperator>(actual);
    }

    [Theory]
    [InlineData(OperatorEnum.sub)]
    public void SubEnumTest(OperatorEnum @enum) {
        var actual = this._provider.GetOperator(@enum);
        Assert.IsType<SubOperator>(actual);
    }

    [Theory]
    [InlineData(OperatorEnum.multiply)]
    public void MultiplyEnumTest(OperatorEnum @enum) {
        var actual = this._provider.GetOperator(@enum);
        Assert.IsType<MultiplyOperator>(actual);
    }

    [Theory]
    [InlineData(OperatorEnum.division)]
    public void DivideEnumTest(OperatorEnum @enum) {
        var actual = _provider.GetOperator(@enum);
        Assert.IsType<DivisionOperator>(actual);
    }

    [Theory]
    [InlineData(null)]
    public void NotSupportedExceptionTest(OperatorEnum @enum) {
        Action act = () => _provider.GetOperator(@enum);
        Assert.Throws<NotSupportedException>(act);
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
        var actual = _sumOperator.Calculate(firstOperand, secondOperand);
        Assert.Equal(actual, expected);
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
    [InlineData(0,1,-1)]
    [InlineData(2,0,2)]
    [InlineData(-3,0,-3)]
    [InlineData(0,-4,4)]
    [InlineData(5,6,-1)]
    [InlineData(6,5,1)]
    [InlineData(7,-8,15)]
    [InlineData(-8,7,-15)]
    [InlineData(-9,10,-19)]
    [InlineData(10,-9,19)]
    [InlineData(-11,-12,1)]
    [InlineData(-12,-11,-1)]
    public void SubtractionBaseTest(int firstOperand, int secondOperand, int expected)
    {
        var actual = _subOperator.Calculate(firstOperand, secondOperand);
        Assert.Equal(actual, expected);
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
    [InlineData(0,1,0)]
    [InlineData(2,0,0)]
    [InlineData(-3,0,0)]
    [InlineData(0,-4,0)]
    [InlineData(5,6,30)]
    [InlineData(6,5,30)]
    [InlineData(7,-8,-56)]
    [InlineData(-8,7,-56)]
    [InlineData(-9,10,-90)]
    [InlineData(10,-9,-90)]
    [InlineData(-11,-12,132)]
    [InlineData(-12,-11,132)]
    public void MultiplicationBaseTest(int firstOperand, int secondOperand, int expected) {
        int actual = this._multiplyOperator.Calculate(firstOperand, secondOperand);
        Assert.Equal(actual, expected);
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
        int actual = this._divisionOperator.Calculate(firstOperand, secondOperand);
        Assert.Equal(actual, expected);
    }
    
    [Theory]
    [InlineData(MaxInt,0)]
    [InlineData(MinInt,0)]
    public void DivisionByZeroTest(int firstOperand, int secondOperand) {
        Action act = () => this._divisionOperator.Calculate(firstOperand, secondOperand);
        Assert.Throws<DivideByZeroException>(act);
    }
}