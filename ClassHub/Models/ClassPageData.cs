using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class ClassPageData
    {
        public Class classInfo { get; set; }
        public List<Activity> assignments { get; set; }
        public List<Activity> quizzes { get; set; }
        public List<Activity> content { get; set; }
        public List<Activity> other { get; set; }
        public string username { get; set; }
        public string classCreator { get; set; }
    }
}