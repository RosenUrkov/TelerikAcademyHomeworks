using System;
using System.Threading;

namespace Timer
{
    public delegate void PreformeAction(int number, string text);
    public class Timer
    {
        public static PreformeAction myDelegate { get; set; }

        static Timer()
        {
            myDelegate += PrintNumber;
            myDelegate += PrintText;
        }       

        private static void PrintNumber(int number, string text)
        {
            System.Console.Write(number + " ");
        }

        private static void PrintText(int number, string text)
        {
            System.Console.WriteLine(text);
        }

        public static void PrintOnTime(int number, string text, int seconds)
        {
            
            while (true)
            {                
                myDelegate(number, text);
                Thread.Sleep(seconds * 1000);
            }

        }
    }
}
