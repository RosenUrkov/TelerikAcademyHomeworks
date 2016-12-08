using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExtractTextFromHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string htmlText = @"
<html>
  <head><title>News</title></head>
  <body><p><a href=""http://academy.telerik.com"">Telerik Academy</a> aims to provide free real-world practical training for young people who want to turn into skilful.NET software engineers.</p></body>
 </html>";

            string body = string.Empty;
            string bodyPattern = @">(.*?)<";

            Regex textValidate = new Regex(bodyPattern);

            string title = string.Empty;
            StringBuilder bodyRebuild = new StringBuilder();

            MatchCollection matches = textValidate.Matches(htmlText);
            title = matches[1].Groups[1].ToString();
            Console.WriteLine(title);

            Regex.Replace(htmlText, @"<title>(.*?)</title>", string.Empty);
            matches = textValidate.Matches(htmlText);
            
            foreach (Match match in matches)
            {
                bodyRebuild.Append(match.Groups[1].ToString().Trim('<','>',' '));
                bodyRebuild.Append(' ');
            }

            body = bodyRebuild.ToString().Trim();
            Console.WriteLine(body);                     
            


        }
    }
}
