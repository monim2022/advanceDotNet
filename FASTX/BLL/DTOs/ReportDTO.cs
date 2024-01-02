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
    public class ReportDTO
    {
        
        public int ReportId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReportDate { get; set; }

        
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
