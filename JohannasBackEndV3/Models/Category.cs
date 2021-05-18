using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}