using Phase04.SimpleCalculator.Business.Abstraction;

namespace Phase04.SimpleCalculator.Business.OperatorBusiness.Operators
{
    public class SumOperator : IOperator
    {
        public int Calculate(int first, int second)
        {
            return first + second;
        }
    }
}