using System;

namespace HanoiTowers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Hanoi(4, 'A', 'B', 'C');
        }

        private static void Hanoi(int diskNumber, char from, char middle, char to)
        {
            if(diskNumber == 1)
            {
                Console.WriteLine("Moving " + diskNumber + " from " + from + " to " + to);
                return;
            }

            Hanoi(diskNumber - 1, from, to, middle);
            Console.WriteLine("Moving " + diskNumber + " from " + from + " to " + to);
            Hanoi(diskNumber - 1, middle, from, to);
        }
    }
}
