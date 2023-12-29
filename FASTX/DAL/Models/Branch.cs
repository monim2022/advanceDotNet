using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        [StringLength(20)]
        public string ManagerName { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public string BranchName { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        
    }
}
