using LearningRessource.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningRessource.Services.Interface;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace LearningRessource.Controllers
{
    public class LearningController : Controller
    {

        readonly ILearningRessourceService _ILearningRessourceService;

        public LearningController(ILearningRessourceService learningRessourceService)
        {
            this._ILearningRessourceService = learningRessourceService;
        }

        // GET: Learnig
        [HttpGet]
        public ActionResult Index()
        {
            List<CourseVM> Courses = new List<CourseVM>();
            try
            {
                Courses = _ILearningRessourceService.GetRessources();
                return View(Courses);
            }
            catch (Exception ex)
            {
                return View("Create");
            }
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Learnig/Create
        [HttpPost]
        public ActionResult Create(CourseVM course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create");
                }
                _ILearningRessourceService.AddRessource(course);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Create");
            }
        }


        // POST: Learnig/Create
        [HttpPost]
        public ActionResult ExportToExcel(IEnumerable<CourseVM> course)
        {
            _ILearningRessourceService.ImportToExcel<CourseVM>(course.ToList());
            return View("Index", course);
        }


    }
}
