using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AHP.Service
{
    public class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectService>().As<Common.IProjectService>();

            builder.RegisterType<AlternativeService>().As<Common.IAlternativeService>();
            builder.RegisterType<AlternativeRankService>().As<Common.IAlternativeRankService>();

            builder.RegisterType<CriteriaService>().As<Common.ICriteriaService>();
            builder.RegisterType<CriteriaRankService>().As<Common.ICriteriaRankService>();
        }
    }
}
