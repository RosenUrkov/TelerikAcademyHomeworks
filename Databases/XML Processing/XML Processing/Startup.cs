namespace XMLProcessing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class Startup
    {
        public static void Main()
        {
            DomParserTask();
            StreamingParserTask();
            LinqToXMLTask();

            LinqXMLPerson();
            StreamXMLAlbum();
            LinqXMLAlbum();
        }

        private static void DomParserTask()
        {
            var document = new XmlDocument();
            document.Load("../../catalog.xml");

            var root = document.DocumentElement;
            var table = new HashSet<XmlNode>();

            foreach (XmlElement element in root.ChildNodes)
            {
                if (int.Parse(element.ChildNodes[2].InnerText) > 250)
                {
                    root.RemoveChild(element);
                }
                else
                {
                    table.Add(element);
                }
            }

            table
                .Select(x =>
                {
                    string result = x.FirstChild.InnerXml + ": \n";

                    foreach (XmlElement song in x.LastChild.ChildNodes)
                    {
                        result += song.InnerText + "\n";
                    }

                    return result;
                })
                .ToList()
                .ForEach(Console.WriteLine);

            document.Save("../../changed-catalog.xml");
        }

        private static void StreamingParserTask()
        {
            var songTitles = new List<string>();

            using (var reader = XmlReader.Create("../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "album")
                    {
                        reader.MoveToFirstAttribute();

                        songTitles.Add(reader.Value);
                    }
                }
            }

            songTitles.ForEach(Console.WriteLine);
        }

        private static void LinqToXMLTask()
        {
            var document = XDocument.Load("../../catalog.xml");

            document
                .Descendants("album")
                .Attributes("name")
                .Select(x => x.Value)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static void LinqXMLPerson()
        {
            using (var reader = new StreamReader("../../Person.txt"))
            {
                var element = new XElement("Person");

                while (!reader.EndOfStream)
                {
                    var tagInfo = reader.ReadLine().Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                    string tagName = tagInfo[0];
                    string tagValue = tagInfo[1];

                    element.Add(new XElement(tagName, tagValue));
                }

                element.Save("../../Person.xml");
            }
        }

        private static void StreamXMLAlbum()
        {
            using (var reader = XmlReader.Create("../../catalog.xml"))
            {
                using (var writer = XmlWriter.Create("../../album.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("album");

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "album")
                        {
                            reader.MoveToFirstAttribute();
                        }

                        if ((reader.Name == "artist" && reader.IsStartElement()) || reader.Name == "name")
                        {
                            string tagName = reader.Name;
                            string tagValue = reader.NodeType == XmlNodeType.Attribute ? reader.Value : reader.ReadElementContentAsString();

                            if (tagName == "name")
                            {
                                writer.WriteStartElement("Details");
                            }

                            writer.WriteStartElement(tagName);
                            writer.WriteValue(tagValue);
                            writer.WriteEndElement();

                            if (tagName == "artist")
                            {
                                writer.WriteEndElement();
                            }
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        private static void LinqXMLAlbum()
        {
            var document = XDocument.Load("../../catalog.xml");

            var album = new XElement("album",

                document.Descendants("album")
                .Select(x =>
                {
                    if (int.Parse(x.Element("year").Value) > 2010)
                    {
                        Console.WriteLine(x.Element("price").Value);
                    }

                    return new XElement("Details",
                        new XElement(x.Attribute("name").Name,x.Attribute("name").Value),
                        new XElement(x.Element("artist").Name,x.Element("artist").Value)
                        );
                }));

            album.Save("../../album-linq.xml");
        }
    }
}
