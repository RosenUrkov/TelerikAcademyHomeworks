namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            ConsolePrinter.Print(MathUtils.CalcTriangleArea(3, 4, 5));

            ConsolePrinter.Print(MathUtils.NumberToString(5));

            ConsolePrinter.Print(MathUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            ConsolePrinter.PrintNumbeWithFormating(1.3, "{0:f2}");
            ConsolePrinter.PrintNumbeWithFormating(0.75, "{0:P0}");
            ConsolePrinter.PrintNumbeWithFormating(2.30, "{0,8}");

            ConsolePrinter.Print(MathUtils.CalcPointDistance(new Point(3, -1), new Point(3, 2.5)));

            Student peter = new Student("Peter", "Ivanov", "Sofia", "17.03.1992");
            Student stella = new Student("Stella", "Markova", "Vidin", "03.11.1993");

            ConsolePrinter.PrintWIthFormating("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella.BirthDate));
        }
    }
}
