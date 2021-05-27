using JohannasBackEndV3.DTOs;
using JohannasBackEndV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Managers
{
    public class BudgetManager
    {

        private static BudgetManager _instance;

        public static BudgetManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BudgetManager();
            }
            return _instance;
        }
        private BudgetManager()
        {

        }

        public void CreateBudget(Budget budget)
        {

            using (var db = new MyDBContext())
            {

                db.Budgets.Add(budget);
                db.SaveChanges();
            }
        }

        public void AddCategoryToBudget(AddCategoryToBudgetDTO dto)
        {
            using(var db = new MyDBContext())
            {
                var c = db.Categories.Where(x => x.Name == dto.Category).FirstOrDefault();
                var b = db.Budgets.Where(x => x.BudgetName == dto.Budget).FirstOrDefault();

                var addedCategory = new BudgetCategory
                {
                    Category = c,
                    Budget = b,
                    MaxSpent = dto.MaxSpent
                };

                db.BudgetCategories.Add(addedCategory);
                db.SaveChanges();
            }
        }
    }  
}