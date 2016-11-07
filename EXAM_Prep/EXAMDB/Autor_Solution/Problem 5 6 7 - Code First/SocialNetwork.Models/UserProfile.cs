namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserProfile
    {
        private ICollection<Image> images;
        private ICollection<Message> sentMessages;
        private ICollection<Post> posts;

        public UserProfile()
        {
            this.images = new HashSet<Image>();
            this.sentMessages = new HashSet<Message>();
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
