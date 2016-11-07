namespace SocialNetwork.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        //private ICollection<Users> users;

        //public Image()
        //{
        //    this.users = new HashSet<Users>();
        //}

        [Key]
        public int Id { get; set; }

        //TODO: check how to add URLs ??? public IEnumerable<HttpPostedFile> ImageURL { get; set; }
        //public string ImageURL { get; set; }

        [MaxLength(4)]
        [Required]
        public string FileExtension { get; set; }

        public string ImageURL { get; set; }

        //public virtual ICollection<Users> Users
        //{
        //    get { return this.users; }
        //    set { this.users = value; }
        //}
    }
}
