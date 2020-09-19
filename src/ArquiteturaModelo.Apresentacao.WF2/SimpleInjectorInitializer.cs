using ArquiteturaModelo.Apresentacao.WF2.ViewModels;
using ArquiteturaModelo.Apresentacao.WF2.Views;
using ArquiteturaModelo.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Apresentacao.WF
{
    public static class SimpleInjectorInitializer
    {

        private static Container _container;

        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            _container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            _container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            InitializeContainer(_container);

            _container.Register<FormLotacao>(Lifestyle.Singleton);
         
            _container.Register<LotacaoViewModel>(Lifestyle.Singleton);


            //InitializeContainer(_container);

            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            _container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver =
            //    new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }

        public static Container Container { get => _container; private set { _container = value; } }
    }
}
