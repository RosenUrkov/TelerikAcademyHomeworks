namespace GenericClass
{
    using System;
    using System.Collections.Generic;
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //Here i review some of the implementations
            var list = new List<int>(4);
            var genericList = new GenericList<int>(4);

            Console.WriteLine(list.Capacity);
            Console.WriteLine(genericList.Capacity);
            Console.WriteLine();

            list.Insert(0, 1);
            genericList.InsertElement(0, 1);

            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine(genericList);
            Console.WriteLine();

            list.RemoveAt(0);
            genericList.RemoveElementAt(0);

            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
                genericList.Add(i);
            }
            
            Console.WriteLine(list.Count);
            Console.WriteLine(genericList.Count);
            Console.WriteLine();

            Console.WriteLine(list.IndexOf(15));
            Console.WriteLine(genericList.IndexOf(15));
            Console.WriteLine();

            Console.WriteLine(genericList.Min());
            Console.WriteLine(genericList.Max());
            Console.WriteLine();

            list.Clear();
            genericList.Clear();

            Console.WriteLine(list.Capacity);
            Console.WriteLine(genericList.Capacity);
            Console.WriteLine();

           

        }
    }
}
