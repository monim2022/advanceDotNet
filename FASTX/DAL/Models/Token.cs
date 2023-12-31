﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Token
    {
        public int Id { get; set; }

        public string TokenKey { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ExpiredAt { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
