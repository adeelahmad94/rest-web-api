using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassHub.Models;
using System.Web.Script.Serialization;

namespace ClassHub.Controllers
{
    public class ClassController : Controller
    {
        //
        // GET: /Class/
        public static User u = new User();
        public ActionResult Index()
        {
            //return RedirectToAction("inex");
            return View();
        }
        public ActionResult LoginSignup()
        {
            User u = new User();
            return View(u);
        }

        [HttpPost]
        public ActionResult performLogin(User u)
        {
            String email = u.email;
            String pass = u.password;
            //check fields
            if (email.Equals("") || pass.Equals(""))
                return RedirectToAction("LoginSignup");
            u = LoginDbHandler.login(email, pass);
            if (u != null)
            {
                switch (u.type)
                {
                    case "Student":
                        return RedirectToAction("StudentDashboard");
                        break;
                    case "Teacher":
                        return RedirectToAction("TeacherDashboard");
                        break;
                }
            }
            //else show error
            // Content("<script language='javascript' type='text/javascript'>alert('Invalid email or password');</script>");
            return RedirectToAction("LoginSignup");
        }
        public ActionResult TeacherDashboard()
        {
            ClassDbHandler handler = new ClassDbHandler();
            DashboardPageData data = new DashboardPageData();
            data.classes = handler.getTeacherClasses(2);
            data.userName = handler.getuserInfo(2).fname + handler.getuserInfo(2).lname;

            return View(data);
        }
        public ActionResult StudentDashboard()
        {
            ClassDbHandler handler = new ClassDbHandler();
            DashboardPageData data = new DashboardPageData();
            data.classes = handler.getStudentClasses(2);
            data.userName = handler.getuserInfo(1).fname + handler.getuserInfo(1).lname;
            return View(data);
        }
        public ActionResult ClassPage()
        {

            ClassDbHandler handler = new ClassDbHandler();
            ActivityDbHandler activityHandler = new ActivityDbHandler();
            UserDbHandler userHandler = new UserDbHandler();

            ClassPageData pageData = new ClassPageData();
            pageData.classInfo = handler.getClassInfo(2);
            pageData.assignments = activityHandler.getClassAssignments(2);
            pageData.content = activityHandler.getClassContent(2);
            pageData.quizzes = activityHandler.getClassQuizzes(2);
            pageData.other = activityHandler.getClassOther(2);
            pageData.username = userHandler.getUsername(1);


            return View(pageData);
        }
        public ActionResult ActivityPage()
        {

            ActivityDbHandler activityHandler = new ActivityDbHandler();
            CommentsDbHandler commentHandler = new CommentsDbHandler();
            UserDbHandler handler = new UserDbHandler();

            ActivityPageData pageData = new ActivityPageData();
            pageData.activity = activityHandler.getActivity(1);
            pageData.comments = new List<CommentView>();
            var com = commentHandler.getComments(1);

            foreach (var comment in com)
            {
                CommentView comm = new CommentView();
                comm.comment = comment;
                comm.username = handler.getUsername(comment.uid);
                pageData.comments.Add(comm);

            }


            return View(pageData);
        }
        public ActionResult ManageRequests()
        {
            ClassDbHandler handler = new ClassDbHandler();
            List<Request> requests = handler.getClassRequests(2);
            ViewBag.ClassName = handler.getClassInfo(2).name;
            ViewBag.Requests = requests;
            return View(ViewBag);
        }

        public ActionResult SearchResults()
        {
            
            
           
            return View();
        }
        [HttpPost]
        public ActionResult SearchResults(string searchquery)
        {

            ClassDbHandler handler = new ClassDbHandler();
            List<Class> classes = handler.getSearchClasses(searchquery);
            List<SearchClassData> cl = new List<SearchClassData>();
            foreach (var c in classes)
            {
                SearchClassData s = new SearchClassData();
                s.cl = c;
                if (handler.IsUserJoined(1, c.Id))
                {
                    s.joined = true;
                }
                else
                {
                    s.joined = false;
                }
                cl.Add(s);
            }
            ViewBag.searchquery = searchquery;
            return View(ViewBag.searchquery);
        }

        public ActionResult addClassForm()
        {
            if (u == null || !u.type.Equals("Teacher"))
                return RedirectToAction("index");
            return View();
        }

        [HttpPost]
        public ActionResult addClass()
        {
            String name = Request["name"].Trim();
            String dept = Request["dept"].Trim();
            String inst = Request["inst"].Trim();
            String desc = Request["desc"].Trim();
            //perform check here
            addClassDbHandler.add(u.Id, name, dept, inst, desc, System.DateTime.Now);
            return RedirectToAction("TeacherDashboard");
        }

        public ActionResult EditProfileForm()
        {
            return View(u);
        }

        [HttpPost]
        public ActionResult updateProfile(User u)
        {
            
            
            String fname = Request["fname"].Trim();
            String lname = Request["lname"].Trim();
            String email = Request["email"].Trim();
            String pass = Request["password"];
            String cpass = Request["cpass"];
            //validate fields
            if (fname.Equals("") || lname.Equals("") || email.Equals("") || pass.Equals("") || cpass.Equals(""))
                return RedirectToAction("EditProfileForm");
            else if (pass != cpass)
                return RedirectToAction("EditProfileForm");
            //checking email
            if (email != u.email && !UserDbHandler.checkEmail(email))
                return RedirectToAction("EditProfileForm");
            u=UserDbHandler.updateUser(u.Id,fname,lname,email,pass);
            if (u.type.Equals("Student"))
                return RedirectToAction("StudentDashboard");
            else
                return RedirectToAction("TeacherDashboard");
        }

        public ActionResult AddActivityForm()
        {
            return View();
        }

        public ActionResult EditClassForm()
        {
            return View();
        }
        [HttpPost]
        public string validateEmail(string email) {
            bool x = LoginDbHandler.checkEmail(email);
            if (x)
            {
                return "false";
            }
            else {
                return "true";
            }
        }
        [HttpPost]
        public string searchClasses(string searchquery) {
            ClassDbHandler handler = new ClassDbHandler();
            List<Class> classes = handler.getSearchClasses(searchquery);
            List<SearchViewData> cl = new List<SearchViewData>();
            foreach (var c in classes)
            {
                SearchViewData s = new SearchViewData();
                s.className = c.name;
                s.classDesc = c.desc;
                s.classCreator = c.User.fname +" "+ c.User.lname;

                if (handler.IsUserJoined(1, c.Id))
                {
                    s.joined = true;
                }
                else
                {
                    s.joined = false;
                }
                cl.Add(s);
            }
            var scr = new JavaScriptSerializer();
            var data = scr.Serialize(cl);
            return data;
        }
    }
}
