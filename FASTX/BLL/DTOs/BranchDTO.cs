using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BranchDTO
    {
        public int BranchId { get; set; }

        [Required]
        public string ManagerName { get; set; }
        [Required]
        public int ManagerId { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
