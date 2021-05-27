using JohannasBackEndV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.DTOs
{
    public class AddCategoryToBudgetDTO
    {
        public string Category { get; set; }
        public string Budget { get; set; }

        public decimal MaxSpent { get; set; }
    }
}