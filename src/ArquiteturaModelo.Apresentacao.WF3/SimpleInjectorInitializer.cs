
using ArquiteturaModelo.Apresentacao.WF3;
using ArquiteturaModelo.Apresentacao.WF3.ViewModels;
using ArquiteturaModelo.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ArquiteturaModelo.Apresentacao.WF3
{
    public static class SimpleInjectorInitializer
    {

        private static Container _container;

        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            _container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

           // _container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
           

            _container.Register<Form1>(Lifestyle.Singleton);
         
            _container.Register<LotacaoViewModel>(Lifestyle.Singleton);

            InitializeContainer(_container);


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
