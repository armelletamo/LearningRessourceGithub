using LearningRessource.Models;
using LearningRessource.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningRessource.Controllers
{
    public class LearningController : Controller
    {

        readonly ILearningRepository _learningRepository;
        public LearningController(ILearningRepository learningRepository)
        {
            this._learningRepository = learningRepository;
        }

        // GET: Learnig
        public ActionResult Index()
        {
            return View();
        }

        // POST: Learnig/Create
        [HttpPost]
        public ActionResult Create(Courses course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }
               
                _learningRepository.Add(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Learnig/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Learnig/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Learnig/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Learnig/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
