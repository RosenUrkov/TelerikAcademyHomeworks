using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var current = Console.ReadLine().ToCharArray();
            var target = Console.ReadLine().ToCharArray();

            var n = int.Parse(Console.ReadLine());

            var forbidden = new char[n][];
            for (int i = 0; i < n; i++)
            {
                forbidden[i] = Console.ReadLine().ToCharArray();
            }

            int result = 0;

            int wheelIndex = 0;
            int direction = GetDirection(current, target, wheelIndex);

            while (wheelIndex < 5)
            {
                if (target[wheelIndex] == current[wheelIndex])
                {
                    wheelIndex++;
                    direction = GetDirection(current, target, wheelIndex);
                    continue;
                }

                MoveWheel(current, wheelIndex, direction);
                for (int i = 0; i < forbidden.Length; i++)
                {
                    if (CheckForbidden(current, forbidden[i]))
                    {
                        // todo change the wheel and then return here
                        Console.WriteLine(-1);
                        return;

                        MoveWheel(current, wheelIndex, -direction);
                        result--;
                        break;
                    }
                }

                result++;
            }

            Console.WriteLine(result);
        }

        public static void MoveWheel(char[] currentComb, int wheelIndex, int direction)
        {
            if (currentComb[wheelIndex] == '9' && direction == 1)
            {
                currentComb[wheelIndex] = '0';
                return;
            }
            if (currentComb[wheelIndex] == '0' && direction == -1)
            {
                currentComb[wheelIndex] = '9';
                return;
            }

            currentComb[wheelIndex] = (char)(currentComb[wheelIndex] + direction);
        }

        public static bool CheckForbidden(char[] current, char[] forbidden)
        {
            for (int i = 0; i < 5; i++)
            {
                if (current[i] != forbidden[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetDirection(char[] current, char[] target, int wheelIndex)
        {
           return Math.Abs(target[wheelIndex] - current[wheelIndex]) < 5 ? 1 : -1;
        }
    }
}
