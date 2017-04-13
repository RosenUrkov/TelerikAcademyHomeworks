namespace MathsAndSortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class ComparingTests
    {
        public static void Main()
        {
            var timer = new StopwatchComparer();

            PrintSimpleMathsComparement(timer);

            Console.WriteLine();

            PrintAdvancedMathsComparement(timer);

            Console.WriteLine();

            PrintSortingAlgorithmsComparement(timer);
        }

        public static void PrintSimpleMathsComparement(StopwatchComparer timer)
        {
            Console.WriteLine("Simple maths comparement");

            Console.WriteLine();

            int intResult = 0;
            Console.WriteLine("Int measurement");
            Console.WriteLine(timer.MesureTime(() => { intResult = 5 + 6; }));
            Console.WriteLine(timer.MesureTime(() => { intResult = 5 - 6; }));
            Console.WriteLine(timer.MesureTime(() => { intResult++; }));
            Console.WriteLine(timer.MesureTime(() => { intResult = 5 * 6; }));
            Console.WriteLine(timer.MesureTime(() => { intResult = 5 / 6; }));

            Console.WriteLine();

            long longResult = 0;
            Console.WriteLine("Long measurement");
            Console.WriteLine(timer.MesureTime(() => { longResult = 5 + 6; }));
            Console.WriteLine(timer.MesureTime(() => { longResult = 5 - 6; }));
            Console.WriteLine(timer.MesureTime(() => { longResult++; }));
            Console.WriteLine(timer.MesureTime(() => { longResult = 5 * 6; }));
            Console.WriteLine(timer.MesureTime(() => { longResult = 5 / 6; }));

            Console.WriteLine();

            float floatResult = 0;
            Console.WriteLine("Float measurement");
            Console.WriteLine(timer.MesureTime(() => { floatResult = 5.5f + 6.6f; }));
            Console.WriteLine(timer.MesureTime(() => { floatResult = 5.5f - 6.6f; }));
            Console.WriteLine(timer.MesureTime(() => { floatResult++; }));
            Console.WriteLine(timer.MesureTime(() => { floatResult = 5.5f * 6.6f; }));
            Console.WriteLine(timer.MesureTime(() => { floatResult = 5.5f / 6.6f; }));

            Console.WriteLine();

            double doubleResult = 0;
            Console.WriteLine("Double measurement");
            Console.WriteLine(timer.MesureTime(() => { doubleResult = 5.5 + 6.6; }));
            Console.WriteLine(timer.MesureTime(() => { doubleResult = 5.5 - 6.6; }));
            Console.WriteLine(timer.MesureTime(() => { doubleResult++; }));
            Console.WriteLine(timer.MesureTime(() => { doubleResult = 5.5 * 6.6; }));
            Console.WriteLine(timer.MesureTime(() => { doubleResult = 5.5 / 6.6; }));

            Console.WriteLine();

            decimal decimalResult = 0;
            Console.WriteLine("Decimal measurement");
            Console.WriteLine(timer.MesureTime(() => { decimalResult = 5.5m + 6.6m; }));
            Console.WriteLine(timer.MesureTime(() => { decimalResult = 5.5m - 6.6m; }));
            Console.WriteLine(timer.MesureTime(() => { decimalResult++; }));
            Console.WriteLine(timer.MesureTime(() => { decimalResult = 5.5m * 6.6m; }));
            Console.WriteLine(timer.MesureTime(() => { decimalResult = 5.5m / 6.6m; }));
        }

        public static void PrintAdvancedMathsComparement(StopwatchComparer timer)
        {
            Console.WriteLine("Advanced maths comparement");

            Console.WriteLine();

            float floatResult = 0;
            Console.WriteLine("Float measurement");
            Console.WriteLine(timer.MesureTime(()=> { floatResult = (float)Math.Sqrt(5.5); }));
            Console.WriteLine(timer.MesureTime(() => { floatResult = (float)Math.Log(5.5); }));
            Console.WriteLine(timer.MesureTime(() => { floatResult = (float)Math.Sin(5.5); }));

            Console.WriteLine();

            double doubleResult = 0;
            Console.WriteLine("Double measurement");
            Console.WriteLine(timer.MesureTime(() => { doubleResult = Math.Sqrt(5.5); }));
            Console.WriteLine(timer.MesureTime(() => { doubleResult = Math.Log(5.5); }));
            Console.WriteLine(timer.MesureTime(() => { doubleResult = Math.Sin(5.5); }));

            Console.WriteLine();

            decimal decimalResult = 0;
            Console.WriteLine("Decimal measurement");
            Console.WriteLine(timer.MesureTime(() => { decimalResult = (decimal)Math.Sqrt(5.5); }));
            Console.WriteLine(timer.MesureTime(() => { decimalResult = (decimal)Math.Log(5.5); }));
            Console.WriteLine(timer.MesureTime(() => { decimalResult = (decimal)Math.Sin(5.5); }));
        }

        public static void PrintSortingAlgorithmsComparement(StopwatchComparer timer)
        {
            var sorter = new Sorter();
            var collection = new List<int>() { 5, 6, 1, 2, 9 };

            Console.WriteLine("Compare sorting algorithms");

            Console.WriteLine();

            Console.WriteLine("Int measurement");
            Console.WriteLine(timer.MesureTime(()=>sorter.SelectionSort<int>(collection)));
            Console.WriteLine(timer.MesureTime(()=>sorter.InsertionSort<int>(collection)));
        }
    }
}
