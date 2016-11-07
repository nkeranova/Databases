//namespace SocialNetwork.Models
//{
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//
//    public class Users
//    {
//        //private ICollection<Image> images;
//
//        //private ICollection<Friendships> friendships;
//
//        //private ICollection<ChatMessages> chatMessages;
//
//        //public Users()
//        //{
//        //    this.images = new HashSet<Image>();
//        //    this.friendships = new HashSet<Friendships>();
//        //    this.chatMessages = new HashSet<ChatMessages>();
//        //}
//
//        [Key]
//        public int Id { get; set; }
//
//        //TODO: tagged in posts?!?
//        public int PostId { get; set; }
//
//        public virtual Posts Post { get; set; }
//
//        public int ImageId { get; set; }
//
//        public virtual Image Image { get; set; }
//
//        public int FriendshipsId { get; set; }
//
//        public virtual Friendships Friendships { get; set; }
//
//        public int ChatMessagesId { get; set; }
//
//        public virtual ChatMessages ChatMessages { get; set; }
//
//        //public virtual ICollection<Image> Images
//        //{
//        //    get { return this.images; }
//        //    set { this.images = value; }
//        //}
//
//        //public virtual ICollection<Friendships> Friendships
//        //{
//        //    get { return this.friendships; }
//        //    set { this.friendships = value; }
//        //}
//        //
//        //public virtual ICollection<ChatMessages> ChatMessages
//        //{
//        //    get { return this.chatMessages; }
//        //    set { this.chatMessages = value; }
//        //}
//    }
//}
