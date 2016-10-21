using System;
using System.Xml;

namespace DeleteFromXml
{
    class DeleteFromXml
    {
        static void Main()
        {
            const double MaximumPrice = 20;

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            XmlElement catalogue = doc.DocumentElement;

            bool isRemoved = false;

            foreach (XmlElement album in catalogue.ChildNodes)
            {
                var price = double.Parse(album["price"].InnerText);

                if (isRemoved)
                {
                    catalogue.RemoveChild(album.PreviousSibling);
                    isRemoved = false;
                }

                if (price > MaximumPrice)
                {
                    isRemoved = true;
                }
            }

            if (isRemoved)
            {
                catalogue.RemoveChild(catalogue.LastChild);
            }

            foreach (XmlElement album in catalogue.ChildNodes)
            {
                Console.WriteLine($"{album["name"].InnerText} - Price: {album["price"].InnerText}");
            }
        }
    }
}
