using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExtractFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\input.xml";
            Console.WriteLine(string.Join(" ", ExtractFromXML(path)));//.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        static List<string> ExtractFromXML(string path)
        {
            var nonTag = new List<string>();
            string content = string.Empty;
            using (var reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }

            int startIndex = 0;

            while (content.IndexOf('>', startIndex) != -1)
            {
                StringBuilder word = new StringBuilder();
                for (int i = (content.IndexOf('>', startIndex) + 1); i < (content.IndexOf('<', startIndex)); i++)
                {
                    word.Append(content[i]);
                }
                nonTag.Add(word.ToString());
                startIndex = content.IndexOf('<', startIndex) + 1;
                if (startIndex == 1)
                {
                    break;
                }
            }

            return nonTag;
        }
    }
}
