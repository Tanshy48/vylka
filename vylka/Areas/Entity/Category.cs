using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vylka.Areas.Entity
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть дані")]
        
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
