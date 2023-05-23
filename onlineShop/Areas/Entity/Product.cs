#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineShop.Areas.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть дані")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть дані")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть дані")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Будь ласка, введіть дані")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<CartItem> CartItem { get; set; }

    }
}
