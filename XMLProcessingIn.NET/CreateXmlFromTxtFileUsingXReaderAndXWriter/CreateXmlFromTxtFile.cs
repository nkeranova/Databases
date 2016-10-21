using System.IO;
using System.Text;
using System.Xml;

namespace CreateXmlFromTxtFileUsingXReaderAndXWriter
{
    public class CreateXmlFromTxtFile
    {
        const string personPath = "../../person.txt";

        public static void Main()
        {
            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Indent = true;
            settings.IndentChars = "\t";

            var writer = new XmlTextWriter("../../person.xml", Encoding.UTF8);

            writer.WriteStartDocument();
            writer.WriteStartElement("persons");

            using (var reader = new StreamReader(personPath))
            {
                while (!reader.EndOfStream)
                {
                    writer.WriteStartElement("person");
                    writer.WriteElementString("name", reader.ReadLine());

                    writer.WriteElementString("address", reader.ReadLine());

                    writer.WriteElementString("phone", reader.ReadLine());
                }
            };

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            writer.Dispose();
        }
    }
}
