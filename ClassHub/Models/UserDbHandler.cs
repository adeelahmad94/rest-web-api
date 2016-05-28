using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class UserDbHandler
    {
        private static dbEntities db = new dbEntities();
        public string getUsername(int id) {
            User u =  db.Users.Find(id);
            if (u != null)
            {
                return u.fname + u.lname;
            }
            else {
                return null;
            }
        }

        public static User updateUser(int id,String f,String l,String e,String p)
        {
            User u = db.Users.Find(id);
            if (u != null)
            {
                u.fname = f;
                u.lname = l;
                u.email = e;
                u.password = p;
                if( db.SaveChanges()==1)
                    return db.Users.Find(id);
            }
            return null ;
        }

        public static bool checkEmail(String e)
        {
            List<User> u = db.Users.Where(x=>x.email == e).ToList();
            if (u.Count == 0)
                return true;
            return false;
        }
    }
}