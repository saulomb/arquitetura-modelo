using ArquiteturaModelo.Aplicacao;
using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Apresentacao.WF;
using ArquiteturaModelo.Apresentacao.WF2.Base.ViewModelBase;
using ArquiteturaModelo.Apresentacao.WF2.BaseModel;
using ArquiteturaModelo.Apresentacao.WF2.Models;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Apresentacao.WF2.ViewModels
{
    public class LotacaoViewModel: ViewModel
    {

        private readonly ILotacaoAppServico _appServico;
        //private IEnumerable<LotacaoModel> _pesquisaLotacao;



        public LotacaoViewModel(ILotacaoAppServico appServico)
        {
            this.Model = new LotacaoModel();
            _appServico = appServico;
            //_appServico = SimpleInjectorInitializer.Container.GetInstance<LotacaoAppServico>();
        }


        //public IEnumerable<LotacaoModel> PesquisaLotacao { get { return _pesquisaLotacao; } }


        public IEnumerable<LotacaoModel> ObterLotacaoAtivaPorNome(string nome)
        {
            return _appServico.ObterLotacaoesAtivaPorNome(nome).Select(domain => {
                var vm = new LotacaoModel();
                vm.DominioToModel(domain);
                return vm;
            }).ToList();
        }



        [Notify]
        public byte IdLotacao
        {
            get { return this.Model.IdLotacao; }
            set
            {
                this.Model.IdLotacao = value;

            }
        }


        [Notify]
        public string Descricao
        {
            get { return this.Model.Descricao; }
            set
            {
                this.Model.Descricao = value;
                
            }
        }


        [Notify]
        public string Sigla
        {
            get { return this.Model.Sigla; }
            set
            {
                this.Model.Sigla = value;

            }
        }
        [Notify]
        public bool Inativa
        {
            get { return this.Model.Inativa; }
            set
            {
                this.Model.Inativa = value;

            }
        }


        public Lotacao ViewModelToDominio()
        {
            return new Lotacao
            {
                Id = this.IdLotacao,
                Descricao = this.Descricao,
                Sigla = this.Sigla,
                Inativa = this.Inativa
            };
        }

        public void DominioToViewModel(Lotacao dominio)
        {
            this.IdLotacao = dominio.Id;
            this.Descricao = dominio.Descricao;
            this.Sigla = dominio.Sigla;
            this.Inativa = dominio.Inativa;
        }


    }
}
