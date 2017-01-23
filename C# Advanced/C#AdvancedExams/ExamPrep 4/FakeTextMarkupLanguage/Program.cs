using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTextMarkupLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            var rows = new List<string>();
            for (int i = 0; i < numberOfRows; i++)
            {
                rows.Add(Console.ReadLine());
            }


            var ProcessedRows = new List<string>();
            for (int i = 0; i < rows.Count; i++)
            {
                ProcessedRows.Add(ProcessingRow(rows[i]));
            }

            Console.WriteLine(string.Join("\r\n", ProcessedRows));

        }
       
        static string Upper(string words)
        {
            string result = words.ToUpper();
            return result;
        }

        static string Lower(string words)
        {
            string result = words.ToLower();
            return result;
        }

        static string Toggle(string words)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] >= 'a' && words[i] <= 'z')
                {
                    builder.Append((char)(words[i] - ' '));
                }
                else if (words[i] >= 'A' && words[i] <= 'Z')
                {
                    builder.Append((char)(words[i] + ' '));
                }
                else
                {
                    builder.Append(words[i]);
                }
            }

            return builder.ToString();
        }

        static string Del(string words)
        {
            return string.Empty;
        }

        static string Rev(string words)
        {
            var builder = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                builder.Append(words[i]);
            }
            return builder.ToString();
        }

        static string ProcessingRow(string row)
        {
            string tag = string.Empty;
            string contentWithTags = string.Empty;
            string clearContent = string.Empty;            

            while (row.IndexOf("</") != -1)
            {
                int index = row.IndexOf("</", 0) + 2;
                tag = row.Substring(index, row.IndexOf('>', index) - index);
                contentWithTags = row.Substring(row.LastIndexOf('<', index - 3), row.IndexOf('>', index) + 1 - row.LastIndexOf('<', index - 3));
                clearContent = TagMenu(tag, contentWithTags);
                row = row.Replace(contentWithTags, clearContent);                
            }

            return row;
        }

        static string TagMenu(string tag, string wordWithTags)
        {
            string result = string.Empty;
            if (tag == "upper")
            {
                result = Upper(CutTags(wordWithTags));
            }
            else if (tag == "lower")
            {
                result = Lower(CutTags(wordWithTags));
            }
            else if (tag == "toggle")
            {
                result = Toggle(CutTags(wordWithTags));
            }
            else if (tag == "rev")
            {
                result = Rev(CutTags(wordWithTags));
            }
            else if (tag == "del")
            {
                result = Del(CutTags(wordWithTags));
            }

            return result;
        }

        static string CutTags(string word)
        {
            string result = string.Empty;
            result = word.Substring(word.IndexOf('>') + 1, word.IndexOf("</") - word.IndexOf('>') - 1);
            return result;
        }
    }
}
