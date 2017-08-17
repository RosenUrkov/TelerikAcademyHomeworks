using System;

namespace KMP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = "asdfasfasdffas";
            var pattern = "asfas";

            var failLinks = PrecomputeKMP(pattern);
            Console.WriteLine(string.Join(" ", failLinks));

            var lastMatchIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (lastMatchIndex >= 0 && pattern[lastMatchIndex] != text[i])
                {
                    lastMatchIndex = failLinks[lastMatchIndex];
                }

                lastMatchIndex++;
                if(lastMatchIndex == pattern.Length)
                {
                    Console.WriteLine(i - lastMatchIndex + 1);
                    lastMatchIndex = failLinks[lastMatchIndex];
                }
            }
        }

        public static int[] PrecomputeKMP(string str)
        {
            var failLinks = new int[str.Length + 1];
            failLinks[0] = -1;
            failLinks[1] = 0;

            for (int i = 1; i < str.Length; i++)
            {
                int lastMatchIndex = failLinks[i];
                while (lastMatchIndex >= 0 && str[i] != str[lastMatchIndex])
                {
                    lastMatchIndex = failLinks[lastMatchIndex];
                }

                failLinks[i + 1] = lastMatchIndex + 1;
            }

            return failLinks;
        }
    }
}
