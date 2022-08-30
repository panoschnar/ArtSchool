using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppArtSchool.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        // GET: Public/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)

            base.Dispose(disposing);
        }
    }
}