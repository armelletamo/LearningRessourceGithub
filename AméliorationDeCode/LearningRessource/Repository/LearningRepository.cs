using LearningRessource.Repository.Interface;
using LearningRessource.Repository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LearningRessource.Repository
{
    public class LearningRepository : ILearningRepository
    {
        private List<Course> CourseRessources = new List<Course>();
        private Context _context = new Context(AppDomain.CurrentDomain.BaseDirectory);
        public void Add(Course myCourse)
        {
            _context.Add(myCourse);
        }
        
        public List<Course> GetCourses()
        {
          return  _context.Get();
        }
    }

   
}