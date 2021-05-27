using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Models
{
    public class BudgetCategory : Entity
    {
        public virtual Category Category { get; set; }
        public virtual Budget Budget { get; set; }

        public decimal MaxSpent { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

        //public BudgetCategory()
        //{
        //    Purchases = new List<Purchase>();
        //}
    }
}