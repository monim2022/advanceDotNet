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
    public class DeliveryStatusDTO
    {
        public int Id { get; set; }
        
        public DAL.Enums.Delivery_Status Status { get; set; }

        public DateTime Timestamp { get; set; }

        public int PackageId { get; set; }
        public int? LastUpdatedBy { get; set; } 
        public virtual Package Package { get; set; }
    }
}
