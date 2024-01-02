using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public string OrderStatus { get; set; }
    }
}
