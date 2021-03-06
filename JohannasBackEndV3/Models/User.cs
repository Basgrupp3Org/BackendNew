using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JohannasBackEndV3.Models
{
    public class User : Entity
    {
        public string Password { get; set; }
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        public decimal BalanceUser { get; set; }
        public virtual ICollection<Balance> Balance { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}