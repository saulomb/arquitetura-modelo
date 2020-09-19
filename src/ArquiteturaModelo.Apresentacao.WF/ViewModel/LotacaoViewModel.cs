using ArquiteturaModelo.Aplicacao;
using ArquiteturaModelo.Aplicacao.Interfaces;

using ArquiteturaModelo.Apresentacao.WF;
using ArquiteturaModelo.Apresentacao.WF.Model.Comum;
using ArquiteturaModelo.Apresentacao.WF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ArquiteturaModelo.Apresentacao.WF.ViewModel
{
    public class LotacaoViewModel : ViewModel<LotacaoModel>
    {

        private readonly ILotacaoAppServico _lotacaoAppServico;
        private readonly IPessoaAppServico _pessoaAppServico;

        public LotacaoViewModel() : base(new LotacaoModel()) 
        {
            bool isInWpfDesignerMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);


            if (!isInWpfDesignerMode)
            {
                _lotacaoAppServico = UnityInitializer.Container.Resolve<LotacaoAppServico>();
                _pessoaAppServico = UnityInitializer.Container.Resolve<PessoaAppServico>();

            }
        }


        public IEnumerable<LotacaoModel> ObterLotacoesPorNome(string nome)
        {

            IEnumerable<LotacaoModel> lotacaoViewModels = _lotacaoAppServico.ObterLotacaoesAtivaPorNome(nome).Select(domain =>
            {
                var vm = new LotacaoModel();
                vm.DominioToModel(domain);
                return vm;
            }).ToList();

            return lotacaoViewModels;
        }



    }
}
