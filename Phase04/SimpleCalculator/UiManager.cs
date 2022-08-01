using Phase04.SimpleCalculator.Business;
using Phase04.SimpleCalculator.Business.Enums;

namespace Phase04.SimpleCalculator
{
    internal class UiManager
    {
        private static readonly Dictionary<string, OperatorEnum> SOperatorSigns = new()
        {
            {"+", OperatorEnum.Sum },
            {"-", OperatorEnum.Sub },
            {"*", OperatorEnum.Multiply },
            {"/", OperatorEnum.Division }
        };

        private readonly Calculator _calculator;

        public UiManager(Calculator calculator)
        {
            _calculator = calculator;
        }

        public void StartUI()
        {
            SayHi();
            var operatorType = GetOperator();
            var firstOperand = GetOperand("first");
            var secondOperand = GetOperand("second");
            Calculate(operatorType, firstOperand, secondOperand);
        }

        private static string? GetNumberString(string name)
        {
            Console.WriteLine($"Write a non-decimal number for '{name} operand:");
            return Console.ReadLine();
        }

        private static int GetOperand(string name)
        {
            var numberString = GetNumberString(name);
            while (!int.TryParse(numberString, out _))
            {
                Console.WriteLine($"Cannot parse given number '{numberString}'");
                numberString = GetNumberString(name);
            }
            return int.Parse(numberString);
        }

        private static OperatorEnum GetOperator()
        {
            var operatorSign = GetOperatorSign();
            while (!SOperatorSigns.ContainsKey(operatorSign))
            {
                Console.WriteLine($"Given operator '{operatorSign}' is not valid!");
                operatorSign = GetOperatorSign();
            }
            return SOperatorSigns[operatorSign];
        }

        private static string GetOperatorSign()
        {
            Console.WriteLine($"Write operator sign ({string.Join(',', SOperatorSigns.Keys)}):");
            return Console.ReadLine().Trim();
        }

        private static void SayHi()
        {
            Console.WriteLine("Hi user");
            Console.WriteLine("How you doing?");
        }

        private void Calculate(OperatorEnum operatorType, int firstOperand, int secondOperand)
        {
            var result = _calculator.Calculate(firstOperand, secondOperand, operatorType);
            Console.WriteLine($"{operatorType}({firstOperand}, {secondOperand}) = {result}");
        }
    }
}