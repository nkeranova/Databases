namespace SocialNetwork.ConsoleClient.Models
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType("Post")]
    public class PostXmlModel
    {
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Users { get; set; }
    }
}
