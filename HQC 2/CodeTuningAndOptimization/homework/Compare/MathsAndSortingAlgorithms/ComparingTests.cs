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
            Console.WriteLine("Add: " + timer.MesureTime(() => { intResult = 5 + 6; }));
            Console.WriteLine("Substract: " + timer.MesureTime(() => { intResult = 5 - 6; }));
            Console.WriteLine("Increment: " + timer.MesureTime(() => { intResult++; }));
            Console.WriteLine("Multiply: " + timer.MesureTime(() => { intResult = 5 * 6; }));
            Console.WriteLine("Divide: " + timer.MesureTime(() => { intResult = 5 / 6; }));

            Console.WriteLine();

            long longResult = 0;
            Console.WriteLine("Long measurement");
            Console.WriteLine("Add: " + timer.MesureTime(() => { longResult = 5 + 6; }));
            Console.WriteLine("Substract: " + timer.MesureTime(() => { longResult = 5 - 6; }));
            Console.WriteLine("Increment: " + timer.MesureTime(() => { longResult++; }));
            Console.WriteLine("Multiply: " + timer.MesureTime(() => { longResult = 5 * 6; }));
            Console.WriteLine("Divide: " + timer.MesureTime(() => { longResult = 5 / 6; }));

            Console.WriteLine();

            float floatResult = 0;
            Console.WriteLine("Float measurement");
            Console.WriteLine("Add: " + timer.MesureTime(() => { floatResult = 5.5f + 6.6f; }));
            Console.WriteLine("Substract: " + timer.MesureTime(() => { floatResult = 5.5f - 6.6f; }));
            Console.WriteLine("Increment: " + timer.MesureTime(() => { floatResult++; }));
            Console.WriteLine("Multiply: " + timer.MesureTime(() => { floatResult = 5.5f * 6.6f; }));
            Console.WriteLine("Divide: " + timer.MesureTime(() => { floatResult = 5.5f / 6.6f; }));

            Console.WriteLine();

            double doubleResult = 0;
            Console.WriteLine("Double measurement");
            Console.WriteLine("Add: " + timer.MesureTime(() => { doubleResult = 5.5 + 6.6; }));
            Console.WriteLine("Substract: " + timer.MesureTime(() => { doubleResult = 5.5 - 6.6; }));
            Console.WriteLine("Increment: " + timer.MesureTime(() => { doubleResult++; }));
            Console.WriteLine("Multiply: " + timer.MesureTime(() => { doubleResult = 5.5 * 6.6; }));
            Console.WriteLine("Divide: " + timer.MesureTime(() => { doubleResult = 5.5 / 6.6; }));

            Console.WriteLine();

            decimal decimalResult = 0;
            Console.WriteLine("Decimal measurement");
            Console.WriteLine("Add: " + timer.MesureTime(() => { decimalResult = 5.5m + 6.6m; }));
            Console.WriteLine("Substract: " + timer.MesureTime(() => { decimalResult = 5.5m - 6.6m; }));
            Console.WriteLine("Increment: " + timer.MesureTime(() => { decimalResult++; }));
            Console.WriteLine("Multiply: " + timer.MesureTime(() => { decimalResult = 5.5m * 6.6m; }));
            Console.WriteLine("Divide: " + timer.MesureTime(() => { decimalResult = 5.5m / 6.6m; }));
        }

        public static void PrintAdvancedMathsComparement(StopwatchComparer timer)
        {
            Console.WriteLine("Advanced maths comparement");

            Console.WriteLine();

            float floatResult = 0;
            Console.WriteLine("Float measurement");
            Console.WriteLine("SQRT: " + timer.MesureTime(() => { floatResult = (float)Math.Sqrt(5.5); }));
            Console.WriteLine("Natural Log: " + timer.MesureTime(() => { floatResult = (float)Math.Log(5.5); }));
            Console.WriteLine("Sinus: " + timer.MesureTime(() => { floatResult = (float)Math.Sin(5.5); }));

            Console.WriteLine();

            double doubleResult = 0;
            Console.WriteLine("Double measurement");
            Console.WriteLine("SQRT: " + timer.MesureTime(() => { doubleResult = Math.Sqrt(5.5); }));
            Console.WriteLine("Natural Log: " + timer.MesureTime(() => { doubleResult = Math.Log(5.5); }));
            Console.WriteLine("Sinus: " + timer.MesureTime(() => { doubleResult = Math.Sin(5.5); }));

            Console.WriteLine();

            decimal decimalResult = 0;
            Console.WriteLine("Decimal measurement");
            Console.WriteLine("SQRT: " + timer.MesureTime(() => { decimalResult = (decimal)Math.Sqrt(5.5); }));
            Console.WriteLine("Natural Log: " + timer.MesureTime(() => { decimalResult = (decimal)Math.Log(5.5); }));
            Console.WriteLine("Sinus: " + timer.MesureTime(() => { decimalResult = (decimal)Math.Sin(5.5); }));
        }

        public static void PrintSortingAlgorithmsComparement(StopwatchComparer timer)
        {
            // the quicksort must be last because he changes the array itself
            // instad of others that copies hem and then do the sorting
            // that makes it kinda unfair but im too lazy to fix it
            var sorter = new Sorter();

            Console.WriteLine("Compare sorting algorithms");

            Console.WriteLine();

            var intCollection = new List<int>() { 5, 6, 1, 2, 9, 0, -4, 18, 562 };
            Console.WriteLine("Int measurement");
            Console.WriteLine("Selection sort: " + timer.MesureTime(() => sorter.SelectionSort<int>(intCollection)));
            Console.WriteLine("Insertion sort: " + timer.MesureTime(() => sorter.InsertionSort<int>(intCollection)));
            Console.WriteLine("Quicksort: " + timer.MesureTime(() => sorter.QuickSort<int>(intCollection, 0, intCollection.Count - 1)));

            Console.WriteLine();

            var doubleCollection = new List<double>() { 5.51, 6.82, 1.6, 0.0272, 9.12, 0.63, -4.2, -0.0189, 0.562 };
            Console.WriteLine("Double measurement");
            Console.WriteLine("Selection sort: " + timer.MesureTime(() => sorter.SelectionSort<double>(doubleCollection)));
            Console.WriteLine("Insertion sort: " + timer.MesureTime(() => sorter.InsertionSort<double>(doubleCollection)));
            Console.WriteLine("Quicksort: " + timer.MesureTime(() => sorter.QuickSort<double>(doubleCollection, 0, doubleCollection.Count - 1)));

            Console.WriteLine();

            var stringCollection = new List<string>() { "asd", "pesho", "ivan", "kockata", "chasovnik", "yutiq", "akumulator" };
            Console.WriteLine("String measurement");
            Console.WriteLine("Selection sort: " + timer.MesureTime(() => sorter.SelectionSort<string>(stringCollection)));
            Console.WriteLine("Insertion sort: " + timer.MesureTime(() => sorter.InsertionSort<string>(stringCollection)));
            Console.WriteLine("Quicksort: " + timer.MesureTime(() => sorter.QuickSort<string>(stringCollection, 0, stringCollection.Count - 1)));

            Console.WriteLine();
        }
    }
}
