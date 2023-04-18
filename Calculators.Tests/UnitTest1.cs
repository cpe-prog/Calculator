using Calculators.Math;
using Xunit;

namespace Calculators.Tests
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(new double[] { 2, 3, 10 }, 15)]
        public void AddCalculationTest(double[] numbers, double expected)
        {

            var addOperator = new AddOperation(); 
            var addResult = addOperator.Calculate(numbers.ToArray());

            switch (addOperator.Symbol)
            {
                case '+':
                    Assert.Equal(expected, addResult);
                    break;
            }

        }
        
        [Theory]
        [InlineData(new double[] { -5, 5}, 0)]
        public void SubtractCalculationTest(double[] numbers, double expected)
        {
            var subtractOperator = new SubtractOperation();
            var subtractResult = subtractOperator.Calculate(numbers.ToArray());
            switch (subtractOperator.Symbol)
            {
                case '-':
                    Assert.Equal(expected, subtractResult);
                    break;
            }
        }
        
        [Theory]
        [InlineData(new double[] { 5, 5}, 25)]
        public void MultiplyCalculationTest(double[] numbers, double expected)
        {
            var multiplyOperator = new MultiplyOperation();
            var multiplyResult = multiplyOperator.Calculate(numbers.ToArray());
            switch (multiplyOperator.Symbol)
            {
                case '×':
                    Assert.Equal(expected, multiplyResult);
                    break;
            }
        }
        
        [Theory]
        [InlineData(new double[] { 20, 2}, 30)]
        public void DivideCalculationTest(double[] numbers, double expected)
        {
            var divideOperator = new DivideOperation();
            var divideResult = divideOperator.Calculate(numbers.ToArray());
            switch (divideOperator.Symbol)
            {
                case '÷':
                    Assert.Equal(expected, divideResult);
                    break;
            }
        }
        
        
    }
}