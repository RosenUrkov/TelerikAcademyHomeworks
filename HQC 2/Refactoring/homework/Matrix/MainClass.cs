namespace Matrix
{
    using System;

    using Matrix;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();

            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            var matrix = new int[n, n];
            var manager = new MatrixManager();
            var printer = new ConsolePrinter();

            manager.FillMatrix(matrix);
            manager.PrintMatrix(matrix, printer);
        }
    }
}
