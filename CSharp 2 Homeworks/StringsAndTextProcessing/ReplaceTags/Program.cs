using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReplaceTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string parsedHTML = Regex.Replace(text, "(<a href=\")(.*?)(\">)(.*?)(</a>)", "[$4]($2)");
            Console.WriteLine(parsedHTML);


            //string htmlText = Console.ReadLine();
            //string[] sentences = htmlText.Split(new string[] { "a>" }, StringSplitOptions.RemoveEmptyEntries);

            //string replacedTagsInHtml = string.Empty;
            //string pattern = @"<a href=""([^<]+)"">([^<]+)</";

            //Regex myRegex = new Regex(pattern);
            //StringBuilder rebuild = new StringBuilder();

            //for (int i = 0; i < sentences.Length; i++)
            //{
            //    Match myMatch = myRegex.Match(sentences[i]);
            //    sentences[i] = Regex.Replace(sentences[i], pattern, String.Format("[{1}]({0})", myMatch.Groups[1], myMatch.Groups[2]));
            //    rebuild.Append(sentences[i]);

            //}

            //replacedTagsInHtml = rebuild.ToString();
            //Console.WriteLine(replacedTagsInHtml);



        }
    }
}
