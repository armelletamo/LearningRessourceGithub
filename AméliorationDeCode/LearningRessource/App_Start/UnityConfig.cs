using LearningRessource.Repository;
using LearningRessource.Repository.Interface;
using LearningRessource.Services;
using LearningRessource.Services.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace LearningRessource
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILearningRepository, LearningRepository>();
           container.RegisterType<ILearningRessourceService, LearningRessourceService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}