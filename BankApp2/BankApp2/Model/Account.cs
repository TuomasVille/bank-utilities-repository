﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp2.Model
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public Account(string iban, decimal? balance)
        {
            Iban = iban;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"{Iban}, {Balance:C}";
        }

        [Key]
        [Column("IBAN", TypeName = "nchar(20)")]
        public string Iban { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public long BankId { get; set; }
        public long CustomerId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Balance { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Account")]
        public Bank Bank { get; set; }
        [ForeignKey("BankId")]
        [InverseProperty("Account")]
        public Customer BankNavigation { get; set; }
        [InverseProperty("IbanNavigation")]
        public ICollection<Transaction> Transaction { get; set; }
    }
}
