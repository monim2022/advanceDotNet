using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public  class ManagerSalary
    {
        [Key]
        public int ManagerSalId { get; set; }

        [ForeignKey ("Manager") ]
        public int ManagerId { get; set; }

        [Required]
        public string SalAmmount { get; set; }

        public virtual Manager Manager { get; set; }





        

    }
}
