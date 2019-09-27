using LearningRessource.Repository.Interface;
using LearningRessource.Repository.Models;
using LearningRessource.Services.Interface;
using LearningRessource.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningRessource.Services
{
    public class LearningRessourceService : ILearningRessourceService
    {
        private ILearningRepository _learningrepository;
        
        
        public LearningRessourceService(ILearningRepository learningrepository)
        {
            _learningrepository = learningrepository;
        }

        public void AddRessource(CourseVM courseVM)
        {
            Course myCourse = new Course(); 
            myCourse.Title = courseVM.Title;
            myCourse.Description = courseVM.Description;
            myCourse.StartDate = courseVM.StartDate;
            myCourse.EndDate = courseVM.EndDate;
            _learningrepository.Add(myCourse);
        }

        public List<CourseVM> GetRessources()
        {

            List<CourseVM> courseVM = new List<CourseVM>();
           
            List<Course> myCourses = _learningrepository.GetCourses();
            if (myCourses != null)
            {
                foreach (Course course in myCourses)
                {
                    CourseVM myCourseVM = new CourseVM();
                    myCourseVM.Title = course.Title;
                    myCourseVM.Description = course.Description;
                    myCourseVM.StartDate = course.StartDate;
                    myCourseVM.EndDate = course.EndDate;
                    courseVM.Add(myCourseVM);
                }
            }           
            return courseVM;
        }
    }

}