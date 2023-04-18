using Calculators.Math;
using Xunit;

namespace Calculators.Tests
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(new double[] { 2, 3 }, 5)] 
        [InlineData(new double[] { -2, 3 }, 1)]
        [InlineData(new double[] { 2, -3 }, -1)]
        [InlineData(new double[] { -2, -3 }, -5)] 
        [InlineData(new double[] { 2, 3 }, 6)]
        [InlineData(new double[] { 2, 0 }, double.PositiveInfinity)]
        public void TestCalculate(double[] numbers, double expected)
        {
            var addOperator = new AddOperation();
            var subtractOperator = new SubtractOperation();
            var multiplyOperator = new MultiplyOperation();
            var divideOperator = new DivideOperation();

            var addResult = addOperator.Calculate(numbers.ToArray());
            var subtractResult = subtractOperator.Calculate(numbers.ToArray());
            var multiplyResult = multiplyOperator.Calculate(numbers.ToArray());
            var divideResult = divideOperator.Calculate(numbers.ToArray());

            switch (addOperator.Symbol)
            {
                case '+':
                    Assert.Equal(expected, addResult);
                    break;
                case '-':
                    Assert.Equal(expected, subtractResult);
                    break;
                case '×':
                    Assert.Equal(expected, multiplyResult);
                    break;
                case '÷':
                    Assert.Equal(expected, divideResult);
                    break;
            }
        }
    }
    
}