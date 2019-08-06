using AHP.Model.Common.Model_Interfaces;
using AHP.Models.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.AutoMapper
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<ProjectDto, IProjectModel>().ReverseMap();
            CreateMap<CriterionDto, ICriteriaModel>().ReverseMap();
          // CreateMap<AlternativeView, IAlternativeModel>().ReverseMap();
            //CreateMap<AlternativeRankView, IAlternativeRankModel>().ReverseMap();
            CreateMap<CriteriaRankDto, ICriteriaRankModel>().ReverseMap();

        }

    }
}