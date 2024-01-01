﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string NID { get; set; }

        public DateTime DOB { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }
    }
}
