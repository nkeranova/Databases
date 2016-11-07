using System.ComponentModel.DataAnnotations;

namespace EFCodeFirst.Models
{
    public class Image
    {
        public int Id { get;  set;}

        [Required]
        public byte[] Content { get; set; }

        //public string FilePath { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string OriginalName { get; set; }

        public int? AlbumId { get; set; }

        [Required]
        //[ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }

        //гърми, ако искаме да го направи като връзка one-to-one, ако се наложи виж как става, ако не ползваме one-to-many
        //public int SongId { get; set; }

       // [InverseProperty("Image")]
       // public virtual Song Song { get; set; }
    }
}
