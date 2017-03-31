namespace RefactorLoop
{
    using System;

    public class RefactorDemo
    {
        public static void Main(int[] array)
        {
            int expectedValue = 5;
            bool isFound = false;

            for (int i = 0; i < 100;)
            {
                if ((i % 10) == 0 && array[i] == expectedValue)
                {
                    isFound = true;
                    break;
                }

                Console.WriteLine(array[i]);
            }

            // More code here
            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
