using Phase04.SimpleCalculator.Business.Enums;

namespace Phase04.SimpleCalculator.Business.Abstraction
{
    public interface IOperatorProvider
    {
        IOperator GetOperator(OperatorEnum operatorType);
    }
}