using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RiderDTO
    {
        public int RiderId { get; set; }

        public int UserId { get; set; }

        public int BranchId { get; set; }

        public string VehicaleType { get; set; }

        public double Salary { get; set; }

        public string Status { get; set; }

        public DateTime Created_at { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual User User { get; set; }
    }
}
