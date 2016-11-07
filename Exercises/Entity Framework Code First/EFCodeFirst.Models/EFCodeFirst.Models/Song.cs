using System;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirst.Models
{
    public class Song
    {
        //private ICollection<Image> images;

        public Song()
        {
            //this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }
        //or public int SongId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(50), MinLength(2)]
        public string Title { get; set; }

        public int? Duration { get; set; }

        //One-to-Many relation
        //добра практика е да се дава и Ид
        public Guid AlbumId { get; set; }

        //винаги за да се обозначи една връзка се дава и в дватаа Класа/Таблици от връзката
        //с vurtual!
        public virtual Album Album { get; set; }

        //public virtual ICollection<Image> Images
        //{
        //    get { return this.images; }
        //    set { this.images = value; }
        //}

        //гърми, ако искаме да го направи като връзка one-to-one, ако се наложи виж как става, ако не ползваме one-to-many
        //public int ImageId { get; set; }

        //public virtual Image Image { get; set; }
    }
}
