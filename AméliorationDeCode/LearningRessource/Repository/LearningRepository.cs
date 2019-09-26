using LearningRessource.Models;
using LearningRessource.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningRessource.Repository
{
    public class LearningRepository : ILearningRepository
    {
        private List<Courses> CourseRessources = new List<Courses>();

        public void Add(Courses myCourse)
        {
            CourseRessources.Add(myCourse);
        }
    }
}