using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PackageDTO
    {
        public int PackageId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string DestinationAddress { get; set; }
        public ShippingMethod ShippingMehtod { get; set; }
        public bool? Insurance { get; set; }
        public DateTime EntitmatedDelivery { get; set; }
        public int DiliveryManId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PymentMethod PymentMethod { get; set; }
        public bool? Retuned { get; set; }
        public virtual Rider Rider { get; set; }
    }
}
