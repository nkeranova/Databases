using System;
using System.Linq;
using System.Xml.Linq;

namespace ExtractAllSongsUsingXDocumentAndLINQ
{
    class XDocumentExtractSоngs
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("../../../catalogue.xml");

            Console.WriteLine("Songs in the albums library with LINQ:");

            var songs = from song in doc.Descendants("song")
                        select song.Element("title").Value;
            
            foreach (var song in songs)
            {
                Console.WriteLine($"{song}");
            }

        }
    }
}
