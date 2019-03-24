using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using UpcomingMovies.Services.Implementations;
using UpcomingMovies.Services.Interfaces;
using UpcomingMovies.ViewModels;

namespace UpcomingMovies
{
    public class BootStrapperIoC
    {
        public static void Init()
        {
            ContainerBuilder _builder = new ContainerBuilder();
            RegisterTypesAppServices(_builder);
            IContainer container = _builder.Build();
            AutofacServiceLocator asl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => asl);

        }

        protected static void RegisterTypesAppServices(ContainerBuilder Container)
        {
            Container.RegisterType<MoviesViewModel>().AsSelf();
            Container.RegisterType<MovieDetailViewModel>().AsSelf();
            Container.RegisterType<MoviesService>().As<IMoviesService>();
        }
    }
}
