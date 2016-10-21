using System;
using System.Collections.Generic;
using System.Xml;

namespace ExtractArtistsFromCatalogUsingXPath
{
    class ExtractUsingXPath
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            string xPath = "/catalogue/album/artist";

            var artistNodes = doc.SelectNodes(xPath);

            foreach (XmlElement artist in artistNodes)
            {
                Console.WriteLine(artist.InnerText);
            }

            Console.WriteLine();

            XmlElement catalogue = doc.DocumentElement;

            var albumsCount = ExtractNumberOfAlbumsPerArtist(catalogue);

            foreach (var album in albumsCount)
            {
                Console.WriteLine("{0}: {1} album/s", album.Key, album.Value);
            }
        }

        private static IDictionary<string, int> ExtractNumberOfAlbumsPerArtist(XmlElement catalogue)
        {
            var counter = new Dictionary<string, int>();

            var albums = catalogue.GetElementsByTagName("album");

            foreach (XmlElement album in albums)
            {
                var artist = album["artist"].InnerText;

                if (!counter.ContainsKey(artist))
                {
                    counter[artist] = 0;
                }

                counter[artist]++;
            }

            return counter;
        }
    }
}
