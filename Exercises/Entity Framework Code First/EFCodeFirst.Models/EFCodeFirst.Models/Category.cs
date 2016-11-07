using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Models
{
    public class Category
    {
        private ICollection<Category> subcategories;

        public Category()
        {
            this.subcategories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        [InverseProperty("Subcategories")]
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Subcategories
        {
            get { return this.subcategories; }
            set { this.subcategories = value; }
        }
    }
}
