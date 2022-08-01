using Phase04.SimpleCalculator.Business.Abstraction;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness;

namespace Phase04.SimpleCalculator.Business
{
    public class Calculator
    {
        private readonly IOperatorProvider _operatorProvider;

        public Calculator(IOperatorProvider operatorProvider)
        {
            _operatorProvider = operatorProvider;
        }

        public Calculator() : this(new OperatorProvider())
        {
        }

        public int Calculate(int first, int second, OperatorEnum operatorType)
        {
            var @operator = _operatorProvider.GetOperator(operatorType);
            return @operator.Calculate(first, second);
        }
    }
}