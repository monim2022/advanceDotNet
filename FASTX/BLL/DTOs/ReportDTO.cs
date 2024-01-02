using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReportDTO
    {
        public int ReportId {  get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Reportby { get; set; }

        public virtual User Users { get; set; }



    }
}
