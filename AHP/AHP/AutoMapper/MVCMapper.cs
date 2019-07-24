using AHP.Model.Common.Model_Interfaces;
using AHP.Model.Models;
using AHP.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.AutoMapper
{
    public class MVCMapper : Profile
    {
        public MVCMapper()
        {
            CreateMap<ProjectView, IProjectModel>().ReverseMap();
            CreateMap<ProjectView, ProjectModel>().ReverseMap();

        }
        
    }
}