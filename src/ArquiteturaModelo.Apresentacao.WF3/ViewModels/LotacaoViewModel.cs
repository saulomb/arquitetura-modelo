using ArquiteturaModelo.Aplicacao;
using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Apresentacao.WF3.Base.ViewModelBase;
using ArquiteturaModelo.Apresentacao.WF3.BaseModel;
using ArquiteturaModelo.Apresentacao.WF3.Models;
using ArquiteturaModelo.Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity;

namespace ArquiteturaModelo.Apresentacao.WF3.ViewModels
{
    public class LotacaoViewModel: ViewModel
    {
        
        private readonly ILotacaoAppServico _lotacaoAppServico;
        private readonly IPessoaAppServico _pessoaAppServico;
        //private IEnumerable<LotacaoModel> _pesquisaLotacao;

        // [Dependency]
        // public ILotacaoAppServico AppServico { get; set; }



        public LotacaoViewModel()
        {
            this.Model = new LotacaoModel();
            bool isInWpfDesignerMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

            if (!isInWpfDesignerMode)
            {
                _lotacaoAppServico = UnityInitializer.Container.Resolve<LotacaoAppServico>();
                _pessoaAppServico = UnityInitializer.Container.Resolve<PessoaAppServico>();

            }


        }


       // public IEnumerable<LotacaoModel> PesquisaLotacao { get { return _pesquisaLotacao; } }


        public IEnumerable<LotacaoModel> ObterLotacaoAtivaPorNome(string nome)
        {
            return _lotacaoAppServico?.ObterLotacaoesAtivaPorNome(nome).Select(domain =>
            {
                var vm = new LotacaoModel();
                vm.DominioToModel(domain);
                return vm;
            }).ToList();
        }


        public IEnumerable<PessoaModel> ObterTodosPessoaFisica()
        {
            return _pessoaAppServico?.ObterTodos()               
                .Select(domain =>
            {
                var vm = new PessoaModel();
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


        //public Lotacao ViewModelToDominio()
        //{
        //    return new Lotacao
        //    {
        //        Id = this.IdLotacao,
        //        Descricao = this.Descricao,
        //        Sigla = this.Sigla,
        //        Inativa = this.Inativa
        //    };
        //}

        //public void DominioToViewModel(Lotacao dominio)
        //{
        //    this.IdLotacao = dominio.Id;
        //    this.Descricao = dominio.Descricao;
        //    this.Sigla = dominio.Sigla;
        //    this.Inativa = dominio.Inativa;
        //}


    }
}
