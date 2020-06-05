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
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories= _dbConext.Categories.ToList()
            };
            return View();
        }
    }
}