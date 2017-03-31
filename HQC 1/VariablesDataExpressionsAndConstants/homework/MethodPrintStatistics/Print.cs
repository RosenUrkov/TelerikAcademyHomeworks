namespace MethodPrintStatistics
{
    using System;

    public class Print
    {
        public void PrintStatistics(double[] array, int count)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            double maxValue = double.MinValue;
            double minValue = double.MaxValue;
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                }

                sum += array[i];
            }

            this.ConsolePrint("The highest value of the array is: {0}", maxValue);
            this.ConsolePrint("The lowest value of the array is: {0}", minValue);
            this.ConsolePrint("The average value of the array is: {0:f2}", sum / count);
        }

        private void ConsolePrint(string message, double number)
        {
            Console.WriteLine(message, number);
        }
    }
}
