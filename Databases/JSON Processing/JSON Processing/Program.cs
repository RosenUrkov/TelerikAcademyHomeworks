namespace JSON_Processing
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    public class Program
    {
        public static void Main()
        {
            var client = new WebClient();
            client.DownloadFile("https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw", "../../youtube.xml");

            string json = JsonConvert.SerializeObject(XDocument.Load("../../youtube.xml"), Formatting.Indented);
            using (var writer = new StreamWriter("../../youtube.json"))
            {
                writer.WriteLine(json);
            }

            JObject
                .Parse(json)
                ["feed"]
                ["entry"]
                .Select(x => x["title"])
                .ToList()
                .ForEach(Console.WriteLine);            
        }
    }
}
