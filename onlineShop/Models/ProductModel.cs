#nullable disable
using System.ComponentModel.DataAnnotations;


namespace onlineShop.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
    
}
