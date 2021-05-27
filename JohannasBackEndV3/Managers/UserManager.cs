using JohannasBackEndV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEndV3.Managers
{
    public class UserManager
    {
        private static UserManager _instance;

        public static UserManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserManager();
            }
            return _instance;
        }
        private UserManager()
        {

        }

        public bool CreateUser(User user)
        {
            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(p => p.UserName == user.UserName).FirstOrDefault();
                if (person == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool GetUser(User user)
        {
            using (var db = new MyDBContext())
            {

                if (user != null)
                {
                    var person = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
                    if (person != null)
                    {
                        return true;
                    }
                    else { return false; }

                }
                else
                {
                    return false;
                }
            }
        }

        public void DeleteUserByID(int id)
        {
            using (var db = new MyDBContext())
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);

                db.SaveChanges();
            }
        }
    }
}