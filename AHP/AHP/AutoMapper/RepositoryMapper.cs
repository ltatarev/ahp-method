
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHP.Model.Common.Model_Interfaces;
using AHP.DAL.Entities;


namespace AHP.AutoMapper
{
    public class RepositoryMapper : Profile
    {
        public RepositoryMapper()
        {
            CreateMap<IProjectModel,Project>().ReverseMap();
            CreateMap<ICriteriaModel, Criteria>().ReverseMap();
            CreateMap<IAlternativeModel, Alternative>().ReverseMap();
            CreateMap<ICriteriaRankModel, CriteriaRank>().ReverseMap();
            CreateMap<IAlternativeRankModel, AlternativeRank>().ReverseMap();

            CreateMap<AHP.Models.ProjectView, IProjectModel>().ReverseMap();



        }
    }
}