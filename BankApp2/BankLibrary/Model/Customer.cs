﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankLibrary.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public long BankId { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public Bank Bank { get; set; }
        [InverseProperty("BankNavigation")]
        public ICollection<Account> Account { get; set; }
    }
}
