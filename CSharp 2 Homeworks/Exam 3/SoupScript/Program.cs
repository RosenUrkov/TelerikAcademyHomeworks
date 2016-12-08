using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoupScript
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = new List<string>();
            int linesNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesNumber; i++)
            {
                code.Add(Console.ReadLine());
            }

            code = CorrectComments(code);
            code = ReduceSpaces(code);
            code = CorrectSpaces(code);
            code = Formate(code);

           // Console.WriteLine("------------------------------------------------------------------");

            foreach (var item in code)
            {
                Console.WriteLine(item);
            }

        }

        static List<string> CorrectComments(List<string> code)
        {
            var corrected = new List<string>();
            for (int i = 0; i < code.Count; i++)
            {
                code[i] = code[i].Trim();
                if ((code[i].IndexOf("//") == -1) || (code[i].IndexOf("//") == 0))
                {
                    corrected.Add(code[i]);
                }
                else
                {
                    corrected.Add(code[i].Substring(code[i].IndexOf("//")));
                    corrected.Add(code[i].Substring(0, code[i].IndexOf("//") - 1));
                }
            }
            return corrected;
        }

        static List<string> ReduceSpaces(List<string> code)
        {
            var corrected = new List<string>();
            string temp = string.Empty;
            for (int i = 0; i < code.Count; i++)
            {
                if (code[i] == string.Empty)
                {
                    continue;
                }
                else if (code[i].IndexOf("//") == 0)
                {
                    temp = code[i];
                }
                else
                {
                    temp = string.Join(" ", code[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                }
                corrected.Add(temp);
            }
            return corrected;
        }

        static List<string> CorrectSpaces(List<string> code)
        {
            var corrected = new List<string>();
            var builder = new StringBuilder();
            for (int i = 0; i < code.Count; i++)
            {
                string temp = string.Empty;

                if ((code[i].IndexOf("//") != -1) || (code[i].IndexOf('}') != -1))
                {
                    corrected.Add(code[i]);
                    continue;
                }

                for (int j = 0; j < code[i].Length; j++)
                {
                    if (code[i][j] == '\'')
                    {
                        temp = code[i].Substring(j, code[i].IndexOf('\'', j + 1) - j + 1);
                        builder.Append(temp);
                        j += temp.Length - 1;
                        continue;
                    }

                    if (code[i][j] == ' ')
                    {
                        if ((code[i][j + 1] == '(') || (code[i][j + 1] == ')') || (code[i][j + 1] == ';') || (code[i][j + 1] == ',') || (code[i][j + 1] == '.'))
                        {
                            continue;
                        }
                        if ((code[i][j - 1] == '(') || (code[i][j - 1] == '.') || (code[i][j - 1] == '!') || (code[i][j - 1] == ';'))
                        {
                            continue;
                        }
                        if (code[i][j - 1] == ')')
                        {
                            if (code[i][j + 1] != '{')
                            {
                                continue;
                            }
                        }
                    }

                    if ((code[i][j] == '=') || (code[i][j] == '+') || (code[i][j] == '-') || (code[i][j] == '>') || (code[i][j] == '<') || (code[i][j] == '*') /*||(code[i][j] == '/') || (code[i][j] == '%')*/)
                    {
                        if (code[i][j - 1] != ' ')
                        {
                            builder.Append(' ');
                        }
                        if (code[i][j + 1] != ' ')
                        {
                            builder.Append(code[i][j]);
                            builder.Append(' ');
                            continue;
                        }
                    }

                    if ((code[i][j] == '{') && (code[i][j - 1] == ')'))
                    {
                        builder.Append(' ');
                    }


                    builder.Append(code[i][j]);

                }
                corrected.Add(builder.ToString());
                builder.Clear();
            }

            return corrected;
        }

        static List<string> Formate(List<string> code)
        {
            var corrected = new List<string>();
            var builder = new StringBuilder();
            int counter = 0;


            for (int i = 0; i < code.Count - 1; i++)
            {
                int formula = counter * 4;
                builder.Append(new string(' ', formula));
                if (code[i].IndexOf('{') != -1)
                {
                    counter++;
                }
                if (code[i + 1].IndexOf('}') != -1)
                {
                    counter--;
                }
                builder.Append(code[i]);
                corrected.Add(builder.ToString());
                builder.Clear();
            }
            corrected.Add(code[code.Count - 1]);
            return corrected;
        }
    }
}
