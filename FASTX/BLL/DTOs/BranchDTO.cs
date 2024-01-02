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

        public string BranchName { get; set; }

        public string Location { get; set; }

        public string ContactNumber { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

        public bool Is24HourBranch { get; set; }
    }
}
