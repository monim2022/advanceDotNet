using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }

        [ForeignKey("Package")]
        public int PackageID { get; set; }
        public virtual Package Package { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string TransactionID { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
