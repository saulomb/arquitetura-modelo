using ArquiteturaModelo.Aplicacao;
using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Apresentacao.WF3.Base.View;
using ArquiteturaModelo.Apresentacao.WF3.Base.ViewModelBase;
using ArquiteturaModelo.Apresentacao.WF3.BaseModel;
using ArquiteturaModelo.Apresentacao.WF3.Models;
using ArquiteturaModelo.Apresentacao.WF3.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ArquiteturaModelo.Apresentacao.WF3
{
    public partial class Form1 : BaseForm1
    {

        //private readonly ILotacaoAppServico _appServico;
        // private LotacaoModel currentLotacaoModel = null;

        public Form1() : this(new LotacaoViewModel())
        { }
        public Form1(LotacaoViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();

            
        }


        protected override void OnInitializeBinding()
        {

            this.ViewModel.Bind(this.txtId, t => t.Text, vm => vm.IdLotacao, true, DataSourceUpdateMode.OnPropertyChanged);
            this.ViewModel.Bind(this.txtSigla, t => t.Text, vm => vm.Sigla, true, DataSourceUpdateMode.OnPropertyChanged);
            this.ViewModel.Bind(this.txtDescricao, t => t.Text, vm => vm.Descricao, true, DataSourceUpdateMode.OnPropertyChanged);
            this.ViewModel.Bind(this.ckbInativa, t => t.Checked, vm => vm.Inativa, true, DataSourceUpdateMode.OnPropertyChanged);
            

            saveButton.DataBindings.Add("Enabled", this.ckbInativa, "Checked", true, DataSourceUpdateMode.OnPropertyChanged);

            //this.ViewModel.Model.Bind(this.txtId, t=> t.Text, m=> m.IdLotacao, false, DataSourceUpdateMode.OnPropertyChanged);
            //this.ViewModel.Model.Bind(this.txtSigla, t => t.Text, m => m.Sigla, false, DataSourceUpdateMode.OnPropertyChanged);
            //this.ViewModel.Model.Bind(this.txtDescricao, t => t.Text, m => m.Descricao, false, DataSourceUpdateMode.OnPropertyChanged);
            //this.ViewModel.Model.Bind(this.ckbInativa, t => t.Checked, m => m.Inativa, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.ViewModel.ObterLotacaoAtivaPorNome("Coor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = this.ViewModel.ObterTodosPessoaFisica();
        }
    }



    public class BaseForm1 : FormView<LotacaoViewModel>
    {


        public BaseForm1() : this(new LotacaoViewModel()) { }

        public BaseForm1(LotacaoViewModel viewModel) : base(viewModel)
        {
        }
    }

}
