using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class ClassDbHandler
    {
        private dbEntities db = new dbEntities();

        public List<ClassData> getTeacherClasses(int userId) { 

            List<ClassData> classes = new List<ClassData>();

            var list = db.Classes.Where(x => x.instructor == userId).ToList();




            foreach (var v in list) {

                
                ClassData c = new ClassData{ id= v.Id , name=v.name};
                classes.Add(c);
            }

            return classes; 
        }
        public User getuserInfo(int userId) {
            return db.Users.Find(userId);
        }



        public List<ClassData> getStudentClasses(int user)
        {

            var result = from x in db.Classes
                         join y in db.Enrollments on x.Id equals y.cid
                         where y.uid == user
                         select new ClassData { id = x.Id, name = x.name, notificationCount = y.notifications, description = x.desc };
            return result.ToList();
        }
        public Class getClassInfo(int id) {
            return db.Classes.Find(id);
        }
        public string getClassCreator(int id) {
            return db.Classes.Find(id).User.fname + db.Classes.Find(id).User.lname;
        }

        public List<Request> getClassRequests(int classId) {
            return db.Requests.Where(x => x.cid == classId).ToList();
        }
        public List<Class> getSearchClasses(string query) {
            
            
            return db.Classes.Where(x => x.name.Contains(query)).ToList();
        }
        public bool IsUserJoined(int userId, int classId) {
            var v = db.Enrollments.Where(x => userId == x.uid && classId == x.cid).ToList();
            if (v.Count > 0) {
                return true;

            }
            return false;
        }
    }
}