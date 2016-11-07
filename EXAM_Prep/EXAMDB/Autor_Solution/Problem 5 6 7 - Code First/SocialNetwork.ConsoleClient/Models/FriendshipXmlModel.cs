namespace SocialNetwork.ConsoleClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType("Friendship")]
    public class FriendshipXmlModel
    {
        [XmlAttribute]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public UserXmlModel FirstUser { get; set; }

        public UserXmlModel SecondUser { get; set; }

        [XmlArrayItem(ElementName = "Message")]
        public List<MessageXmlModel> Messages { get; set; }
    }
}
