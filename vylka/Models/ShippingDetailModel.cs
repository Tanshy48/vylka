﻿using System.ComponentModel.DataAnnotations;

namespace vylka.Models
{
    public class ShippingDetailModel
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double AmountPaid { get; set; }
        public string PaymentType { get; set; }
    }
}
