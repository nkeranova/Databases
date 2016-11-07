namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        public int Id { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }

        public int AuthorId { get; set; }

        public virtual UserProfile Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }

        [NotMapped]
        public bool Seen
        {
            get { return this.SeenOn.HasValue; }
        }
    }
}
