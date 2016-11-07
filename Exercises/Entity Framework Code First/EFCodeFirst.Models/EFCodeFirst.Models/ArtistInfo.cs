using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Models
{
    [ComplexType]
    //[Table("Information")]
    public class ArtistInfo
    {
        //[Column("Country")]
        public string Country { get; set; }

        //[Column("Bio")]
        public string Biography { get; set; }

        //[Column("Age", TypeName = "int")]
        public int Age { get; set; }

    }
}
