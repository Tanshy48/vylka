#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace onlineShop.Models
{
    public class ShippingDetailModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введіть будь ласка дані")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Введіть будь ласка дані")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введіть будь ласка дані")]
        public string District { get; set; }
        [Required(ErrorMessage = "Введіть будь ласка дані")]
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "Введіть будь ласка дані")]
        public string DeliveryType { get; set; }
        [Required(ErrorMessage = "Введіть будь ласка дані")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Введіть будь ласка дані")]
        public DateTime CreateDelivery { get; set; }
        
    }
}
