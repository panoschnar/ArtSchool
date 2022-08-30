using DataAccessLayer;
using Entities.Models;
using Entities.Queries;
using PagedList;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace WebAppArtSchool.Areas.Public.Controllers
{
    
    public class TrainerController : BaseController
    {
       
        // GET: Public/Trainer
        [HttpGet]
        public ActionResult Index(TrainerFilteredSettings filterSettings, string sortOrder, int? page, int? pSize)
        {
            //Current State..
            ViewBag.CurrentName = filterSettings.searchName;
            ViewBag.CurrentCoursey = filterSettings.searchCourse;
            ViewBag.CurrentMin = filterSettings.searchMin;
            ViewBag.CurrentMax = filterSettings.searchMax;

            //Filtering..
            (int? minSalary, int? maxSalary) trainerSalaryRange;
            var filteredTrainers = unit.Trainers.Filter(filterSettings, out trainerSalaryRange);

            ViewBag.MinAge = trainerSalaryRange.minSalary;
            ViewBag.MaxAge = trainerSalaryRange.maxSalary;

            //Sorting..
            ViewBag.FirstNameSortParam = string.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LastNameSortParam = string.IsNullOrEmpty(sortOrder) ? "LastNameDesc" : "";  
            ViewBag.TelephoneSortParam = sortOrder == "TelephoneAsc" ? "TelephoneDesc" : "TelephoneAsc";
            ViewBag.SalarySortParam = sortOrder == "SalaryAsc" ? "SalaryDesc" : "SalaryAsc";
            ViewBag.CourseSortParam = sortOrder == "CourseAsc" ? "CourseDesc" : "CourseAsc";


            switch (sortOrder)
            {
                case "FirstNameAsc": filteredTrainers = filteredTrainers.OrderBy(x => x.FirstName).ToList(); break;
                case "FirstNameDesc": filteredTrainers = filteredTrainers.OrderByDescending(x => x.FirstName).ToList(); break;

                case "LastNameAsc": filteredTrainers = filteredTrainers.OrderBy(x => x.LastName).ToList(); break;
                case "LastNameDesc": filteredTrainers = filteredTrainers.OrderByDescending(x => x.LastName).ToList(); break;

                case "TelephoneAsc": filteredTrainers = filteredTrainers.OrderBy(x => x.Phone).ToList(); break;
                case "TelephoneDesc": filteredTrainers = filteredTrainers.OrderByDescending(x => x.Phone).ToList(); break;

                case "SalaryAsc": filteredTrainers = filteredTrainers.OrderBy(x => x.Salary).ToList(); break;
                case "SalaryDesc": filteredTrainers = filteredTrainers.OrderByDescending(x => x.Salary).ToList(); break;

                case "CourseAsc": filteredTrainers = filteredTrainers.OrderBy(x => x.Course.Title).ToList(); break;
                case "CourseDesc": filteredTrainers = filteredTrainers.OrderByDescending(x => x.Course.Title).ToList(); break;

                default: filteredTrainers = filteredTrainers.OrderBy(x => x.LastName).ToList(); break;
            }

            //Pagination..
            int pageSize = pSize ?? 5;  //nullable collehasive operator
            int pageNumber = page ?? 1;

            ViewBag.Courses = unit.Courses.GetAll().Distinct().ToList();


            return View(filteredTrainers.ToPagedList(pageNumber, pageSize));
            //var trainers = unit.Trainers.GetAllWithCourses().OrderBy(x => x.FirstName).ToList();
            //return View(trainers);
        }

        public ActionResult Details(int? id)
        {
            if(id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainer = unit.Trainers.GetTrainerFull(id);
            if(trainer is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(trainer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var courses = unit.Courses.GetAll();
            ViewBag.Courses = courses;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                unit.Trainers.Insert(trainer);
                unit.Complete();
                return Redirect("Index");
            }

            ViewBag.Courses = unit.Courses.GetAll();
            ShowAlert($"You have succesfully add a Trainer!");

            return View(trainer);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainer = unit.Trainers.GetById(id);
            if (trainer is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.Courses = unit.Courses.GetAll();

            return View(trainer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                unit.Trainers.Update(trainer);

                ShowAlert("Trainer has succesfully updated!");
                return RedirectToAction("Index");
            }
            ViewBag.Courses = unit.Courses.GetAll();

            return View(trainer);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var trainer = unit.Trainers.GetById(id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            else
            {
                unit.Trainers.Delete(trainer.TrainerId);
                unit.Complete();
            }
            //ShowAlert($"The Trainer: {trainer.FullName} has been deleted!");
            return RedirectToAction("Index");
        }
       

    }
}