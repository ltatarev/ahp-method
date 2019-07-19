using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace AHP.Repository
{
	public class DIModule : Autofac.Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectRepository>().As<Common.IProjectRepository>();

            builder.RegisterType<CriteriaRepository>().As<Common.ICriteriaRepository>();
            builder.RegisterType<CriteriaRankRepository>().As<Common.ICriteriaRankRepository>();

            builder.RegisterType<AlternativeRepository>().As<Common.IAlternativeRepository>();
            builder.RegisterType<AlternativeRankRepository>().As<Common.IAlternativeRankRepository>();
        }
    }
}
