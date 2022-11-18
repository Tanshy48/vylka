#nullable disable

using System.ComponentModel.DataAnnotations;

namespace vylka.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Будь ласка, введіть дані")]
        [StringLength(30)]

        public string Name { get; set; }
    }
}
