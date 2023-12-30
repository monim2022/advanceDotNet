using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReturnOrderDTO
    {
        public int ReturnOrderId { get; set; }
        [Required]
        public int OriginalOrderId { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int BranchId { get; set; }
    }
}
