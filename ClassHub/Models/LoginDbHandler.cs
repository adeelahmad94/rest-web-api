using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class LoginDbHandler
    {
        private static dbEntities db = new dbEntities();

        public static User login(String e,String pass)
        {
            List<User>l= db.Users.Where(x => x.email.Equals(e) && x.password.Equals(pass)).ToList();
            if (l!=null && l.Count>0)
                return l[0];
            return null;
        }
        public static bool checkEmail(string email){
            
            var v = db.Users.Where(x=>x.email == email).ToList();
            if (v.Count > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}