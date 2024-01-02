using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Rider
    {
        [Key]
        public int RiderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public string VehicaleType { get; set; }

        public double Salary { get; set; }

        public string Status { get; set; }

        public DateTime Created_at { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual User User { get; set; }
    }
}
