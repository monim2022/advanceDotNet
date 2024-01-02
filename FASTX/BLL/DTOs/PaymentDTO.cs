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
    public class PaymentDTO
    {
        public int Id { get; set; }
        
        public string Email { get; set; }

        
        public int PackageID { get; set; }
        public virtual Package Package { get; set; }
        
        public string TransactionType { get; set; }
        
        public string PaymentMethod { get; set; }
        
        public string TransactionID { get; set; }
        
        public double Amount { get; set; }
    }
}
