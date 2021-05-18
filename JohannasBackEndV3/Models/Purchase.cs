using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Models
{
    public class Purchase : Entity
    {
        public virtual User User { get; set; }
        public decimal Price { get; set; }

        public string PurchaseName { get; set; }

        public DateTime Date { get; set; }

      //  public virtual Budget Budget { get; set; }
    }
}