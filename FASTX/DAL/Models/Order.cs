using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [StringLength(20)]
        public string SenderName { get; set; }
        [Required]
        [StringLength(20)]
        public string ReceiverName { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        [Required]
        [StringLength(20)]
        public int AssignedRiderId { get; set; }
        [Required]
        [StringLength(20)]
        public int BranchId { get; set; }
    }
}
