using Phase04.SimpleCalculator.Business.Abstraction;

namespace Phase04.SimpleCalculator.Business.OperatorBusiness.Operators
{
    public class SubOperator : IOperator
    {
        public int Calculate(int first, int second)
        {
            return first - second;
        }
    }
}