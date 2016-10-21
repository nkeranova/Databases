using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CreateXmlFromTxtFile
{
    public class CreateXmlFromTxtFile
    {
        const string person = "../../person.txt";
        public static void Main()
        {
            // you can find the created person.Xml file in ..\CreateXmlFromTxtFile\bin\Debug
            String[] data = File.ReadAllLines("person.txt");
            XElement root = new XElement("person",
                                        from item in data
                                        select new XElement("name", item));
            root.Save("person.Xml");

            Console.WriteLine(@"The person.Xml file was created in CreateXmlFromTxtFile\bin\Debug");

            //or 
            Console.WriteLine("\nOr second way: ");
            StreamReader reader = new StreamReader(person);

            var xmlDoc = new XDocument();
            var rootElement = new XElement("person");

            var line = reader.ReadLine();

            while (line != null)
            {
                var person = new XElement("person");
                person.Add(new XElement("name", line));
                line = reader.ReadLine();

                person.Add(new XElement("address", line));
                line = reader.ReadLine();

                person.Add(new XElement("phone", line));
                line = reader.ReadLine();

                rootElement.Add(person);
            }

            xmlDoc.Add(rootElement);
            Console.WriteLine(xmlDoc);

            xmlDoc.Save("../../person2.xml");
        }
    }
}
