﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Rider
    {
        [Key]
        public int RiderId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int BranchId { get; set; }
        // Other rider-related properties
    }
}
