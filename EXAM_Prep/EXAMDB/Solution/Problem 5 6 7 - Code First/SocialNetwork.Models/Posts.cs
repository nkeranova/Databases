namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Posts
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        [Required]
        public string Content { get; set; }

        public DataType PostingDate { get; set; }
    }
}
