using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace DownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadFile();
        }

        static void DownloadFile()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://telerikacademy.com/Content/Images/news-img01.png", "news-img01.png");
            }
        }
    }
}
