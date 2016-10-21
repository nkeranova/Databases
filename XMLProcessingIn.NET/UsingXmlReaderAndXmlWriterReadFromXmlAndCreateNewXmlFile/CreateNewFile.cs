using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace UsingXmlReaderAndXmlWriterReadFromXmlAndCreateNewXmlFile
{
    public class CreateNewFile
    {
        public static void Main()
        {
            var albums = ExtractAlbums();
            CreateAlbumXmlFile(albums);
        }

        public static void CreateAlbumXmlFile(IDictionary<string, string> albums)
        {
            const string fileName = "../../album.xml";
            var encoding = Encoding.GetEncoding("utf-8");
            using (var writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;

                writer.WriteStartDocument();
                writer.WriteStartElement("catalog");

                foreach (var album in albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album.Key);
                    writer.WriteElementString("artist", album.Value);
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
        }

        public static IDictionary<string, string> ExtractAlbums()
        {
            var albums = new Dictionary<string, string>();

            var albumNames = new List<string>();
            var artists = new List<string>();
            using (var reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "name"))
                    {
                        albumNames.Add(reader.ReadElementString());
                    }

                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "artist"))
                    {
                        artists.Add(reader.ReadElementString());
                    }
                }
            }

            for (var i = 0; i < albumNames.Count; i++)
            {
                albums.Add(albumNames[i], artists[i]);
            }

            return albums;
        }
    }
}

