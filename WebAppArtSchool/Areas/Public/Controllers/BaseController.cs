using DataAccessLayer;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppArtSchool.Areas.Public.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        protected UnitOfWork unit;
        public BaseController()
        {
            unit = new UnitOfWork(db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                unit.Dispose();
            base.Dispose(disposing);
        }

        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }
    }
}