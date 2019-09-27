using LearningRessource.Repository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LearningRessource.Repository
{
    public class Context
    {
        private string jsonPath { get; set; }

        public Context(string path)
        {
            jsonPath = path;
        }
        List<Course> CourseRessources = new List<Course>();

        public void Add(Course course)
        {
            string newJson = null;
            using (StreamReader r = new StreamReader(jsonPath + "Ressources.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    CourseRessources = JsonConvert.DeserializeObject<List<Course>>(json);
                }
                CourseRessources.Add(course);
                newJson = JsonConvert.SerializeObject(CourseRessources);
            }

            File.WriteAllText(jsonPath + "Ressources.json", newJson);
        }

        public List<Course> Get()
        {
            using (StreamReader r = new StreamReader(jsonPath + "Ressources.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Course>>(json);
            }
        }
    }
}