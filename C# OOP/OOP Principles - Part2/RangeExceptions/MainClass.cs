namespace RangeExceptions
{
    using System;
    public class MainClass
    {
        public static void Main()
        {
            try
            {
                var number = 0;
                if (number < 1 || number > 100)
                {
                    throw new InvalidRangeException<int>("Number is not in range.", 1, 100);
                }

            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StartOfRange);
                Console.WriteLine(ex.EndOfRange);
            }

            Console.WriteLine();

            try
            {
                var date = DateTime.Now;                
                if (((date.CompareTo(Convert.ToDateTime("1/1/1980")) > 0) 
                    || (date.CompareTo(Convert.ToDateTime("31/12/2013"))) < 0))
                {
                    throw new InvalidRangeException<DateTime>("Date is not in range", Convert.ToDateTime("1/1/1980"), Convert.ToDateTime("31/12/2013"));
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StartOfRange);
                Console.WriteLine(ex.EndOfRange);
            }
        }
    }
}
