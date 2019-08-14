using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.AutoMapper
{
    public class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MVCMapper>().As<IMapper>().SingleInstance();
            builder.RegisterType<RepositoryMapper>().As<IMapper>().SingleInstance();
        }
    }
}