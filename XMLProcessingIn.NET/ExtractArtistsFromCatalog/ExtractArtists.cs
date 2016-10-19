using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractArtistsFromCatalog
{
    class ExtractArtists
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            XmlNode rootNode = doc.DocumentElement;

            Console.WriteLine("List of all artists in current catalague: ");

            //foreach (XmlNode node in rootNode.ChildNodes)
            //{
            //    Console.WriteLine(node["artist"].InnerText);
            //}
        }
    }
}
