using System;
using System.Xml;

namespace ExtractAllSongsUsingXmlReader
{
    class ExtractAllSongs
    {
        static void Main(string[] args)
        {
            var path = "../../../catalogue.xml";

            Console.WriteLine("Songs in the albums library with LINQ:");

            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        Console.WriteLine($"{reader.ReadElementContentAsString()}");
                    }
                }
            }
        }
    }
}
