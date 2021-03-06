﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Manager
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string CellNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
      
       
    }
}
