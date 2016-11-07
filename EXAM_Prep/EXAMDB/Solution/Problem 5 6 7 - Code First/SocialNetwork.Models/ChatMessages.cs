//namespace SocialNetwork.Models
//{
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//
//    class ChatMessages
//    {
//        //private ICollection<Users> users;
//
//        //public ChatMessages()
//        //{
//        //    this.users = new HashSet<Users>();
//        //}
//
//        [Key]
//        public int Id { get; set; }
//
//        //TODO: to add friendship
//        //public string Friendship { get; set; }
//
//        public string Author { get; set; }
//
//        [Required]
//        public string MessageContent { get; set; }
//
//        public DataType SendingDateTime { get; set; }
//
//        public DataType SeeingDateTime { get; set; }
//
//        //public virtual ICollection<Users> Users
//        //{
//        //    get { return this.users; }
//        //    set { this.users = value; }
//        //}
//    }
//}
//