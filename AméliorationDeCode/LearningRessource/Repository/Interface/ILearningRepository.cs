﻿using LearningRessource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningRessource.Repository.Interface
{
   public  interface ILearningRepository
    {
        void Add(Courses myCourse);
    }
}
