using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.Service.CalculationClasses;
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

            builder.RegisterType<PriorityCalculator>().As<Common.AHPCalculation.IPriorityCalculator>();
            builder.RegisterType<MatrixCreator>().As<Common.AHPCalculation.IMatrixCreator>();
            builder.RegisterType<DataPreparation>().As<Common.AHPCalculation.IDataPreparation>();
            builder.RegisterType<FinalResultCalculator>().As<Common.IFinalResultCalculator>();
        }
    }
}
