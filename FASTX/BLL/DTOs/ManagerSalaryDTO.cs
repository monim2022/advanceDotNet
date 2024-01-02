using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public  class ManagerSalaryDTO
    {

        public int ManagerSalId { get; set; }

        public int ManagerId { get; set; }

        public decimal SalAmmount { get; set; }

        public virtual Manager Manager { get; set; }

    }
}
