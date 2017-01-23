namespace Phones
{
    using System;
    static class GSMCallHistoryTest
    {
        public static void TestCallHistory()
        {
            var myPhone = new Phone();
            myPhone.MakeCall("0887631407", 205);
            myPhone.MakeCall("0874566780", 95);
            myPhone.MakeCall("0891432423", 1242);

            int longestCallIndex = -1;
            int longestCall = int.MinValue;

            Console.WriteLine("Make calls and print call history of a phone:");
            Console.WriteLine();
            for (int i = 0; i < myPhone.CallHistory.Count; i++)
            {
                if (myPhone.CallHistory[i].DurationSeconds > longestCall)
                {
                    longestCall = myPhone.CallHistory[i].DurationSeconds;
                    longestCallIndex = i;
                }

                Console.WriteLine(myPhone.CallHistory[i].CallTime);
                Console.WriteLine(myPhone.CallHistory[i].DurationSeconds);
                Console.WriteLine(myPhone.CallHistory[i].Number);
                Console.WriteLine();

            }

            Console.WriteLine("Calculate price of the calls in the history:");
            Console.WriteLine(myPhone.CallHistoryPrice());
            Console.WriteLine();

            myPhone.RemoveCall(longestCallIndex);

            Console.WriteLine("Remove the longest call and calculate price again:");
            Console.WriteLine(myPhone.CallHistoryPrice());
            Console.WriteLine();

            myPhone.ClearHistory();

            Console.WriteLine("Clear history and print it again:");
            foreach (var item in myPhone.CallHistory)
            {
                Console.WriteLine(item.CallTime);
                Console.WriteLine(item.DurationSeconds);
                Console.WriteLine(item.Number);
                Console.WriteLine();
            }
            Console.WriteLine();


        }
    }
}
