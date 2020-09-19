using ArquiteturaModelo.Aplicacao;
using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;
using ArquiteturaModelo.Dominio.Servicos;
using ArquiteturaModelo.Infra.Contexto;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using ArquiteturaModelo.Infra.Repositorio.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ArquiteturaModelo.Infra.CrossCutting.IoC
{
    public static class BootStrapperUnity
    {

        public static void Register(UnityContainer container)
        {
            container.RegisterType<ILotacaoAppServico, LotacaoAppServico>()
                    .RegisterType<IPessoaAppServico, PessoaAppServico>()
                    .RegisterType<ILotacaoServico, LotacaoServico>()
                    .RegisterType<ILotacaoRepositorio, LotacaoRepositorio>()
                    .RegisterType<IPessoaServico, PessoaServico>()
                    .RegisterType<IPessoaRepositorio, PessoaRepositorio>()

                    .RegisterType<IDapperContexto, DapperContexto>()
                    .RegisterType<IUnitOfWork, UnitOfWork>();

           

        }

    }
}
