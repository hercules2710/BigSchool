using Microsoft.AspNet.Identity;
using NguyenMinhHien_lab3.Models;
using NguyenMinhHien_lab3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenMinhHien_lab3.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbConext;
        public CoursesController()
        {
            _dbConext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories= _dbConext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbConext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbConext.Courses.Add(course);
            _dbConext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}