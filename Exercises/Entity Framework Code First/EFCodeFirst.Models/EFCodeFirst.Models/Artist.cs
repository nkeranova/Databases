using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Models
{
    public class Artist
    {
        private ICollection<Album> albums;
        public Artist()
        {
            this.Members = 1;
            this.albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        //[Required(ErrorMessage = "You must enter valid name!")]
        //[MinLength(2)]
        //[MaxLength(100)]
        public string Name { get; set; }

        //[Range(1, 70)]
        //public int Age { get; set; }

        [Index]
        //[Index(IsClustered = true)]
        //[Index(IsUnique = true)] //когато искаме тази колона да бъде уникална
        public GenderType Gender { get; set; }
        public int Members { get;  set; }

        //public ArtistInfo Information { get; set; }
        public virtual ICollection<Album> Albums 
        {
            get { return this.albums; }
            set { this.albums = value; }
        }

        [NotMapped]
        public bool IsGroup
        {
            get { return this.Members > 1; }
        }
    }
}
