﻿namespace GoshoCode
{
    using System;
    using System.Text;

    public class GoshoCode
    {
        public static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int numberOfLines = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();
            for (int i = 0; i < numberOfLines; i++)
            {
                builder.Append(Console.ReadLine());
                builder.Append(' ');
            }

            string text = builder.ToString();

            GetOperation(text, word);
        }

        private static void GetOperation(string text, string word)
        {
            int indexOfWord = text.IndexOf(word);
            int indexOfDot = text.IndexOf('.', indexOfWord + word.Length);
            int indexOfExclam = text.IndexOf('!', indexOfWord + word.Length);

            int indexOfOperation = 0;
            if (indexOfExclam != -1 && indexOfDot != -1)
            {
                indexOfOperation = Math.Min(indexOfDot, indexOfExclam);
            }
            else
            {
                indexOfOperation = Math.Max(indexOfDot, indexOfExclam);
            }

            char operation = text[indexOfOperation];

            long result = OperationMenu(operation, text, indexOfWord, word, indexOfOperation);
            Console.WriteLine(result);
        }

        private static long OperationMenu(char operation, string text, int indexOfWord, string word, int indexOfOperation)
        {
            long result = 0;
            if (operation == '.')
            {
                result = DotOperation(text, indexOfWord, word, indexOfOperation);
            }
            else if (operation == '!')
            {
                result = ExclmOperation(text, indexOfWord, word);
            }

            return result;
        }

        private static long DotOperation(string text, int indexOfWord, string word, int indexOfOperation)
        {
            int length = word.Length;
            string subText = text.Substring(indexOfWord + length, indexOfOperation - (indexOfWord + length));
            long result = 0;
            for (int i = 0; i < subText.Length; i++)
            {
                if (subText[i] == ' ')
                {
                    continue;
                }

                result += subText[i] * length;
            }

            return result;
        }

        private static long ExclmOperation(string text, int indexOfWord, string word)
        {
            int indexOfStart = 0;
            for (int i = indexOfWord; i >= 0; i--)
            {
                if ((text[i] >= 'A') && (text[i] <= 'Z'))
                {
                    indexOfStart = i;
                    break;
                }
            }

            string subText = text.Substring(indexOfStart, indexOfWord - indexOfStart - 1);
            int length = word.Length;
            long result = 0;

            for (int i = 0; i < subText.Length; i++)
            {
                if (subText[i] == ' ')
                {
                    continue;
                }

                result += subText[i] * length;
            }

            return result;
        }
    }
}
