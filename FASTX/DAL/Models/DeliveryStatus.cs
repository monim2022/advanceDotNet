﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DeliveryStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Enums.Delivery_Status Status { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public int? LastUpdatedBy { get; set; } //user id
        public virtual Package Package { get; set; }
    }
}
