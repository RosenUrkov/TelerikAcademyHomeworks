using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingMoves
{
    class Program
    {
        static int[] numbers;
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = 0;
            long allMovesValue = 0;
            int position = 0;

            while (true)
            {
                string temp = Console.ReadLine();
                if (temp == "stop")
                {
                    break;
                }

                string[] movesSplit = temp.Split(' ');
                int counts = int.Parse(movesSplit[0]);
                string direction = movesSplit[1];
                int intDirection = GetDIrection(direction);
                int step = (int.Parse(movesSplit[2]) * intDirection);


                long currentMoveValue = 0;
                while (counts > 0)
                {
                    int nextPosition = position + step;
                    while (nextPosition < 0)
                    {
                        nextPosition = numbers.Length + nextPosition;
                    }

                    currentMoveValue += numbers[(nextPosition) % numbers.Length];


                    position = nextPosition;

                    counts--;
                }

                allMovesValue += currentMoveValue;

                counter++;

            }

            Console.WriteLine("{0:f1}", allMovesValue / (double)(counter));
        }


        static int GetDIrection(string direction)
        {
            int step = 1;
            if (direction == "left")
            {
                step = -1;
            }
            return step;
        }

    }
}
