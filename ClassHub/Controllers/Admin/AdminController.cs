using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ClassHub.Controllers.Admin
{
    public class AdminController : Controller
    {
        //ADMIN PANEL
        public ActionResult AdminDashboard()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminSignup()
        {
            return View();
        }
    }
}