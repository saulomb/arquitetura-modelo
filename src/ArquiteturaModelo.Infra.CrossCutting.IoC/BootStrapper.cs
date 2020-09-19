using ArquiteturaModelo.Aplicacao;
using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;
using ArquiteturaModelo.Dominio.Servicos;
using ArquiteturaModelo.Infra.Contexto;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using ArquiteturaModelo.Infra.Repositorio.Dapper;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void Register(Container container)
        {
            //container.Register<ILotacaoAppServico, LotacaoAppServico>(Lifestyle.Transient);
            //container.Register<ILotacaoServico, LotacaoServico>(Lifestyle.Transient);
            //container.Register<ILotacaoRepositorio, LotacaoRepositorio>(Lifestyle.Transient);
            container.Register<ILotacaoAppServico, LotacaoAppServico>(Lifestyle.Singleton);
            container.Register<ILotacaoServico, LotacaoServico>(Lifestyle.Singleton);

            container.Register<ILotacaoRepositorio, LotacaoRepositorio>(Lifestyle.Singleton);
            container.Register<IDapperContexto, DapperContexto>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);



        }

//        public static void RegisterDisposableTransient<TService, TImplementation>(
//this Container c)
//where TImplementation : class, IDisposable, TService
//where TService : class
//        {
//            var scoped = Lifestyle.Scoped;
//            var r = Lifestyle.Transient.CreateRegistration<TImplementation>(c);
//            r.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "ignore");
//            c.AddRegistration(typeof(TService), r);
//            c.RegisterInitializer<TImplementation>(o => scoped.RegisterForDisposal(c, o));
//        }
    }
}
