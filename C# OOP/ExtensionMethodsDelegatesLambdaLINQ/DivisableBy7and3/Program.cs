namespace DivisableBy7and3
{
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] list = { 6, 21, 7, 63, 13 };

            var devisableList = list.Where(x => x % 21 == 0).ToList();
            System.Console.WriteLine(string.Join(" ",devisableList));

            var divisableListLinq =
                from number in list
                where number % 2 == 0
                select number;
            System.Console.WriteLine(string.Join(" ",devisableList));
        }
    }
}
