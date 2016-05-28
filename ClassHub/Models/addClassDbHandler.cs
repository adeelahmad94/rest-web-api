using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class addClassDbHandler
    {
        private static dbEntities db = new dbEntities();
        public static int add(int id, String name, String i, String d, String desc, DateTime dt)
        {
            Class c = new Class();
            c.Id = id;
            c.name = name;
            c.instructor = id;
            c.dept = d;
            c.institution = i;
            c.desc = desc;
            c.created = dt;
            db.Classes.Add(c);
            return db.SaveChanges();
        }

    }
}