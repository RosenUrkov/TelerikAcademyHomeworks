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
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            var result = 0;
            var failLink = PreComputeKMP(pattern);

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
                    result++;
                    j = failLink[j];
                }
            }

            for (int k = 1; k < pattern.Length; k++)
            {
                var prefix = pattern.Substring(0, k);
                var prefFailLink = PreComputeKMP(prefix);

                var suffix = pattern.Substring(k, pattern.Length - k);
                var suffFailLink = PreComputeKMP(suffix);

                var prefRes = 0;
                var suffRes = 0;

                int p = 0;
                int s = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    while (p >= 0 && prefix[p] != text[i])
                    {
                        p = prefFailLink[p];
                    }
                    while (s >= 0 && suffix[s] != text[i])
                    {
                        s = suffFailLink[s];
                    }

                    ++p;
                    ++s;

                    if (p == prefix.Length)
                    {
                        prefRes++;
                        p = prefFailLink[p];
                    }
                    if (s == suffix.Length)
                    {
                        suffRes++;
                        s = suffFailLink[s];
                    }
                }

                result += (prefRes * suffRes);
            }

            Console.WriteLine(result);
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