using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace DAL.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public string DestinationAddress { get; set; }
        [Required]
        public ShippingMethod ShippingMehtod { get; set; }
        public bool? Insurance { get; set; }
        [Required]
        public DateTime EntitmatedDelivery { get; set; }
        [Required]
        [ForeignKey("Rider")]
        public int DiliveryManId { get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        public PymentMethod PymentMethod { get; set; }
        public bool? Retuned { get; set; }
        //public DeliveryStatus DeliveryStatus { get; set; }
        public virtual Rider Rider { get; set; }
    }
}
