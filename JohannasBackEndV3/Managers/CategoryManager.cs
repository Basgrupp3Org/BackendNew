using JohannasBackEndV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Managers
{
    public class CategoryManager
    {
        private static CategoryManager _instance;

        public static CategoryManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CategoryManager();
            }
            return _instance;
        }
        private CategoryManager()
        {

        }

        public void CreateCategory(Category category)
        {
            
            using (var db = new MyDBContext())
            {

                db.Categories.Add(category);
                db.SaveChanges();
            }
        }
    }
}