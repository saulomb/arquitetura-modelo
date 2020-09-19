using ArquiteturaModelo.Apresentacao.WF2.Base.View;
using ArquiteturaModelo.Apresentacao.WF2.Base.ViewModelBase;
using ArquiteturaModelo.Apresentacao.WF2.Models;
using ArquiteturaModelo.Apresentacao.WF2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquiteturaModelo.Apresentacao.WF2.Views
{



    public partial class FormLotacao : BaseForm1
    {

        //public FormLotacao() : base(new LotacaoViewModel())
        //{

        //}

        public FormLotacao(LotacaoViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
            
            dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
        }


        protected override void OnInitializeBinding()
        {
            this.ViewModel.Bind(this.txtId, t => t.Text, vm => vm.IdLotacao, false, DataSourceUpdateMode.OnPropertyChanged);
            this.ViewModel.Bind(this.txtSigla, t => t.Text, vm => vm.Sigla, false, DataSourceUpdateMode.OnPropertyChanged);
            this.ViewModel.Bind(this.txtDescricao, t => t.Text, vm => vm.Descricao, false, DataSourceUpdateMode.OnPropertyChanged);
            this.ViewModel.Bind(this.ckbInativa, t => t.Checked, vm => vm.Inativa, false, DataSourceUpdateMode.OnPropertyChanged);
            

            //txtSigla.DataBindings.Add("Text", this.ViewModel, "Sigla", false, DataSourceUpdateMode.OnPropertyChanged);


            //label4.DataBindings.Add("Text", txtSigla, "Text", false, DataSourceUpdateMode.OnValidation);
            //button1.DataBindings.Add("Enabled", ckbInativa, "Checked", false, DataSourceUpdateMode.OnValidation);


            //txtSigla.DataBindings.Add(new Binding("Text", this.ViewModel, "Sigla", true, DataSourceUpdateMode.OnPropertyChanged));




        }

        private void button3_Click(object sender, EventArgs e)
        {
            var lotacaoBindingList = new BindingList<LotacaoModel>(this.ViewModel.ObterLotacaoAtivaPorNome(txtPesquisaNome.Text).ToList());
            dataGridView1.DataSource = lotacaoBindingList;
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            var model = (LotacaoModel)dataGridView1.CurrentRow.DataBoundItem;

            this.ViewModel.IdLotacao = model.IdLotacao;
            this.ViewModel.Descricao = model.Descricao;
            this.ViewModel.Sigla = model.Sigla;
            this.ViewModel.Inativa = model.Inativa;

            //txtId.Text = model.IdLotacao.ToString();
            //txtDescricao.Text = model.Descricao;
            //txtSigla.Text = model.Sigla;
            //ckbInativa.Checked = model.Inativa;
            //txtId.DataBindings["Text"].WriteValue();
            //txtSigla.DataBindings["Text"].WriteValue();
            //txtDescricao.DataBindings["Text"].WriteValue();
            //ckbInativa.DataBindings["Checked"].WriteValue();



        }
    }

    public class BaseForm1 : FormView<LotacaoViewModel>
    {
        //public BaseForm1() : this(new LotacaoViewModel()) { }

        public BaseForm1(LotacaoViewModel viewModel) : base(viewModel)
        {
        }
    }


}
