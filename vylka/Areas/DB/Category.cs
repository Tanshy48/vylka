using System.ComponentModel.DataAnnotations;

namespace vylka.Areas.DB
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Product { get; set; }
    }
}
