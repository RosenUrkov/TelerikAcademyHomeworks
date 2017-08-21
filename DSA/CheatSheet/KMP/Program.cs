using System;

namespace KMP
{
    class Program
    {
        static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; ++i)
            {
                Console.Write(" ");
            }

            Console.WriteLine(pattern);
        }

        static void Main()
        {
            var pattern = "alabala";
            var failLink = PreComputeKMP(pattern);

            var text = "xalalalalabalababalabala";            

            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (j >= 0 && pattern[j] != text[i])
                {
                    j = failLink[j];
                }

                ++j;
                if (j == pattern.Length)
                {
                    PrintMatch(i - j + 1, pattern);
                    j = failLink[j];
                }
            }
        }

        static int[] PreComputeKMP(string str)
        {
            var failLink = new int[str.Length + 1];
            failLink[0] = -1;
            failLink[1] = 0;
            for (int i = 1; i < str.Length; ++i)
            {
                int j = failLink[i];
                while (j >= 0 && str[i] != str[j])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            return failLink;
        }
    }
}