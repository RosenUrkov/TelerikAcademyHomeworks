namespace DefineClasses
{
    using System;
    using Phones;

    class DefineClasses
    {
        static void Main()
        {
            GSMTest.TestPhone();
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine(Phone.IPhone4S);
            Console.WriteLine("----------------------------------------------------");

            GSMCallHistoryTest.TestCallHistory();

        }
    }
}
