using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class ActivityDbHandler
    {
        private dbEntities db = new dbEntities();

        public List<Activity> getClassAssignments(int classId) 
        {
            return db.Activities.Where(x => x.cid == classId && x.type == "assignment").ToList() ;
        }
        public List<Activity> getClassQuizzes(int classId)
        {
            return db.Activities.Where(x => x.cid == classId && x.type == "quiz").ToList();
        }
        public List<Activity> getClassContent(int classId)
        {
            return db.Activities.Where(x => x.cid == classId && x.type == "content").ToList();
        }
        public List<Activity> getClassOther(int classId) {
            return db.Activities.Where(x => x.cid == classId && x.type == "other").ToList();
        }
        public Activity getActivity(int activityId) {
            return db.Activities.Find(activityId);
        }
    }
}