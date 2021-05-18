using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Models
{
    public class Budget : Entity
    {
        public string BudgetName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<BudgetCategory> BudgetCategories { get; set; }
    }
}