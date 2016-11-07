namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public int FirstUserId { get; set; }

        public UserProfile FirstUser { get; set; }

        public int SecondUserId { get; set; }

        public UserProfile SecondUser { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
