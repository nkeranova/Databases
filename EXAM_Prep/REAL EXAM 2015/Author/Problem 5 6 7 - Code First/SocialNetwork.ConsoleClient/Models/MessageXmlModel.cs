namespace SocialNetwork.ConsoleClient.Models
{
    using System;

    [Serializable]
    public class MessageXmlModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }
    }
}
