using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppArtSchool.Areas.Public.Controllers
{
    public class CourseController : Controller
    {
        // GET: Public/Course
        public ActionResult Sing()
        {
            return View();
        }

        public ActionResult Dance()
        {
            return View();
        }

        public ActionResult Paint()
        {
            return View();
        }
    }
}