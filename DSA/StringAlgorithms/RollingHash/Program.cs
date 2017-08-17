using System;

namespace RollingHash
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = "asdfasfasdffas";
            var pattern = "asf";

            var module = 1_000_000_007;
            var baseNumber = 211;
            var maxBasePower = FastPower(baseNumber, pattern.Length - 1, module);

            var targetHash = GetHash(pattern, 0, pattern.Length, baseNumber, module);
            var currHash = GetHash(text, 0, pattern.Length, baseNumber, module);

            if (targetHash == currHash && CheckString(pattern, text, 0))
            {
                Console.WriteLine(0);
            }

            for (int i = 1; i <= text.Length - pattern.Length; i++)
            {
                currHash = RollHash(currHash, maxBasePower, text[i - 1], text[i - 1 + pattern.Length], baseNumber, module);
                if (targetHash == currHash && CheckString(pattern, text, i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static int GetHash(string text, int startIndex, int endIndex, int hashBase, int module)
        {
            int hash = 0;
            for (int i = endIndex - 1; i >= startIndex; i--)
            {
                hash = (hash * hashBase + text[i]) % module;
            }

            return hash;
        }

        public static int RollHash(int hash, int maxBasePower, char pervChar, char nextChar, int hashBase, int module)
        {
            var result = hash - pervChar;
            result /= hashBase;
            result += (nextChar * maxBasePower) % module;

            return result;
        }

        public static bool CheckString(string target, string text, int textStart)
        {
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] != text[textStart + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int FastPower(int number, int power, int module)
        {
            if (power == 1)
            {
                return number;
            }

            if (power % 2 == 1)
            {
                return (number * (FastPower(number, power - 1, module)) % module) % module;
            }

            var result = FastPower(number, power / 2, module);
            return (result * result) % module;
        }
    }
}
