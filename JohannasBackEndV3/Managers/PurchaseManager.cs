using JohannasBackEndV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Managers
{
    public class PurchaseManager
    {
        private static PurchaseManager _instance;


        public static PurchaseManager GetInstance()
        {

            if (_instance == null)
            {
                _instance = new PurchaseManager();
            }
            return _instance;
        }
        private PurchaseManager()
        {

        }

        public void CreatePurchase(Purchase purchase)
        {
            using (var db = new MyDBContext())
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
            }
        }
    }
}