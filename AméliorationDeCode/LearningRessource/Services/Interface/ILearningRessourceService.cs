using LearningRessource.Repository.Models;
using LearningRessource.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningRessource.Services.Interface
{
    public interface ILearningRessourceService
    {
        void AddRessource(CourseVM course);
        List<CourseVM> GetRessources();
    }
}
