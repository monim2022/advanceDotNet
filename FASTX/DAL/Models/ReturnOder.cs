using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReturnOder
    {
        [Key]
        public int ReturnOrderId { get; set; }
        [Required]
        public int OriginalOrderId { get; set; }
        [Required]
        [StringLength(20)]
        public string Reason { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        [Required]
        public int BranchId { get; set; }
    }
}
