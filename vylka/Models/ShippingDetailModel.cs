#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace vylka.Models
{
    public class ShippingDetailModel
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        [Required]
        public string DeliveryType { get; set; }
        
    }
}
