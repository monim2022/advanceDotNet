﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public string OrderStatus { get; set; }
    }
}
    