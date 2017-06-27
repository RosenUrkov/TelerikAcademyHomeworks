using System;

namespace NestedLoops
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int loopsCount = int.Parse(Console.ReadLine());

            RecursiveLoops(1, loopsCount, "");
        }

        private static void RecursiveLoops(int currentLoop, int loopsCount, string loopsOutput)
        {
            if (currentLoop > loopsCount)
            {
                Console.WriteLine(loopsOutput.Trim());
                return;
            }
            
            for (int i = 1; i <= loopsCount; i++)
            {
                RecursiveLoops(currentLoop + 1, loopsCount, loopsOutput + i);
            }
        }
    }
}
