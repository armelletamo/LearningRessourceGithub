using LearningRessource.Models;
using LearningRessource.Repository.Interface;
using LearningRessource.Services.Interface;
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

        public void AddRessource(Courses course)
        {
            throw new NotImplementedException();
        }
    }
}