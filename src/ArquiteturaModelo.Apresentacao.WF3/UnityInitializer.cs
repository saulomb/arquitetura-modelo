using ArquiteturaModelo.Infra.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ArquiteturaModelo.Apresentacao.WF3
{
    public static class UnityInitializer
    {

        private static UnityContainer _container;


        public static void Initialize()
        {
            _container = new UnityContainer();


            InitializeContainer(_container);

            //_container.Register<Form1>(Lifestyle.Singleton);

            //_container.Register<LotacaoViewModel>(Lifestyle.Singleton);

            InitializeContainer(_container);

        }

        private static void InitializeContainer(UnityContainer container)
        {
            BootStrapperUnity.Register(container);
        }


        public static UnityContainer Container { get => _container; private set { _container = value; } }


    }
}
