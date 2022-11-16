#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace vylka.Models
{
    public class ShippingDetailModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Але де дані?")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Але де дані?")]
        public string City { get; set; }
        [Required(ErrorMessage = "Але де дані?")]
        public string District { get; set; }
        [Required(ErrorMessage = "Але де дані?")]
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "Але де дані?")]
        public string DeliveryType { get; set; }
        [Required(ErrorMessage = "Але де дані?")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Але де дані?")]
        public DateTime CreateDelivery { get; set; }
        
    }
}
