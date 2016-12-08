using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> brackets = new Stack<char>();
            string text = Console.ReadLine();
            bool isCorrect = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    brackets.Push(text[i]);
                }
                else if (text[i] == ')')
                {
                    if (brackets.Count > 0)
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        isCorrect = false;
                        break;
                    }
                }

            }
            if ((isCorrect) && (brackets.Count == 0))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }
}
