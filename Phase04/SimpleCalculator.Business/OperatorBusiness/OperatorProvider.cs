using Phase04.SimpleCalculator.Business.Abstraction;
using Phase04.SimpleCalculator.Business.Enums;
using Phase04.SimpleCalculator.Business.OperatorBusiness.Operators;

namespace Phase04.SimpleCalculator.Business.OperatorBusiness
{
    public class OperatorProvider : IOperatorProvider
    {
        public IOperator GetOperator(OperatorEnum operatorType)
        {
            return operatorType switch
            {
                OperatorEnum.Sum => new SumOperator(),
                OperatorEnum.Sub => new SubOperator(),
                OperatorEnum.Multiply => new MultiplyOperator(),
                OperatorEnum.Division => new DivisionOperator(),
                _ => throw new NotSupportedException(),
            };
        }
    }
}