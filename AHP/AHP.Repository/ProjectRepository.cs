using System;

using AutoMapper;
using AHP.DAL.Entities;
using AHP.Model;
using AHP.Models.Common;
using AHP.Repository.Common;
using System;
using System.Collections.Generic;

namespace AHP.Repository
{
	public class ProjectRepository : IProjectRepository
	{

        static ProjectRepository()
    {
        Storage = new List<Project>();

            //Here needs to be added Project entity (Username, ProjectName, Description...)

    }
        #region Properties

        public static List<Project> Storage { get; set; }

        #endregion Properties
    }
}
