using Calculators.Math;
using Xunit;

namespace Calculators.Tests
{
    public class AdditionCalculationTests
    {
        [Theory]
        [InlineData(new double[] { 2, 3, 10 }, 15)]
        [InlineData(new double[] { -2, 3 }, 1)]
        [InlineData(new double[] { 2, -3 }, -1)]
        [InlineData(new double[] { -2, -3 }, -5)]
        [InlineData(new double[] { 2, 3 }, 5)]
        public void TestAddCalculate(double[] numbers, double expected)
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
    }

    public class SubtractionCalculationTests
    {
        [Theory]
        [InlineData(new double[] { -5, 5}, 0)] 
        [InlineData(new double[] { -2, 3 }, 1)]
        [InlineData(new double[] { 2, -3 }, -1)]
        [InlineData(new double[] { -2, -3 }, -5)] 
        [InlineData(new double[] { -2, 8 }, 6)]
        public void TestSubtractCalculate(double[] numbers, double expected)
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
    }

   public class MultiplicationCalculationTests
   {
       [Theory]
       [InlineData(new double[] { 5, 5}, 25)] 
       [InlineData(new double[] { 2, 3 }, 6)]
       [InlineData(new double[] { 3, 3 }, 9)]
       [InlineData(new double[] { -2, -3 }, -5)] 
       [InlineData(new double[] { 10, 3 }, 30)]
       public void TestMultiplyCalculate(double[] numbers, double expected)
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
   }
   
   public class DivisionCalculationTests
   {
       [Theory]
       [InlineData(new double[] { 20, 2}, 30)]
       [InlineData(new double[] { 20, 10 }, 2)]
       [InlineData(new double[] { 50, 10 }, 5)]
       [InlineData(new double[] { 10, 10 }, 1)]
       [InlineData(new double[] { 0, 0 }, 0)]
       public void TestDivideCalculate(double[] numbers, double expected)
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