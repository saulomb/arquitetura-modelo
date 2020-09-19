using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Apresentacao.WF.Base;
using ArquiteturaModelo.Apresentacao.WF.Model.Base;
using ArquiteturaModelo.Apresentacao.WF.Model.Comum;
using ArquiteturaModelo.Apresentacao.WF.ViewModel;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquiteturaModelo.Apresentacao.WF
{
    public partial class Form2 : BaseForm1
    {
        private readonly ILotacaoAppServico _appServico;
        private LotacaoModel currentLotacaoModel = null;
       
        
        private Form2() : base(new LotacaoViewModel())
        {      }




        public Form2(ILotacaoAppServico appServico):base(new LotacaoViewModel())
        {
            _appServico = appServico;
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            currentLotacaoModel = (LotacaoModel)dataGridView1.CurrentRow.DataBoundItem;


             lotacaoModelBindingSource.DataSource = currentLotacaoModel;

            //currentLotacaoVM = (LotacaoModel)lotacaoVMbindingSource.Current;



            //this.ViewModel.Model = currentLotacaoModel;

            //this.ViewModel.Model.IdLotacao = currentLotacaoModel.IdLotacao;
            //this.ViewModel.Model.Descricao = currentLotacaoModel.Descricao;
            //this.ViewModel.Model.Sigla = currentLotacaoModel.Sigla;
            //this.ViewModel.Model.Inativa = currentLotacaoModel.Inativa;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            IEnumerable<LotacaoModel> lotacaoViewModels = _appServico.ObterTodos().Select(domain => {
                var vm = new LotacaoModel();
                vm.DominioToModel(domain);
                return vm; }).ToList();

   

            var lotacaoBindingList = new BindingList<LotacaoModel>(lotacaoViewModels.ToList());
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
           // lotacaoVMbindingSource.DataSource = lotacaoBindingList;
            dataGridView1.DataSource = lotacaoBindingList;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

      

            //currentLotacaoModel = lotacaoBindingList.FirstOrDefault();
            //this.ViewModel.Model.IdLotacao = currentLotacaoModel.IdLotacao;
            //this.ViewModel.Model.Descricao = currentLotacaoModel.Descricao;
            //this.ViewModel.Model.Sigla = currentLotacaoModel.Sigla;
            //this.ViewModel.Model.Inativa = currentLotacaoModel.Inativa;


            //var lotacaoObservable = new ObservableCollection<LotacaoViewModel>(lotacaoViewModels);
            //lotacaoVMbindingSource.DataSource = lotacaoObservable;
            //dataGridView1.DataSource = lotacaoObservable;

            //button1.DataBindings.Add("Enabled", ckInativo, "Checked");

            // txtId.DataBindings.Add("Text", lotacaoVMbindingSource.Current, "IdLotacao");
            //txtDescricao.DataBindings.Add("Text", lotacaoVMbindingSource., "Descricao", false, DataSourceUpdateMode.OnPropertyChanged);
            //txtSigla.DataBindings.Add("Text", lotacaoVMbindingSource.Current, "Sigla",false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox2.DataBindings.Add("Text", txtSigla, "Text");

            //ckInativo.DataBindings.Add("Checked", lotacaoVMbindingSource.Current, "Inativo");





        }


        protected override void OnInitializeBinding()
        {
            //txtId.DataBindings.Add("Text", this.ViewModel.Model, "IdLotacao", false, DataSourceUpdateMode.OnPropertyChanged);
            //txtDescricao.DataBindings.Add("Text", this.ViewModel.Model, "Descricao", false, DataSourceUpdateMode.OnPropertyChanged);
            //txtSigla.DataBindings.Add("Text", this.ViewModel.Model, "Sigla", false, DataSourceUpdateMode.OnPropertyChanged);
            //ckInativo.DataBindings.Add("Checked", this.ViewModel.Model, "Inativa", false, DataSourceUpdateMode.OnPropertyChanged);



            //this.ViewModel.Model.Bind(this.txtId, t => t.Text, model => model.IdLotacao, false, DataSourceUpdateMode.OnPropertyChanged);
            //this.ViewModel.Model.Bind(this.txtDescricao, t => t.Text, model => model.Descricao, false, DataSourceUpdateMode.OnPropertyChanged);
            //this.ViewModel.Model.Bind(this.txtSigla, t => t.Text, model => model.Sigla, false, DataSourceUpdateMode.OnPropertyChanged);
            //this.ViewModel.Model.Bind(this.ckInativo, t => t.Checked, model => model.Inativa, false, DataSourceUpdateMode.OnPropertyChanged);
            //button1.DataBindings.Add("Enabled", ckInativo, "Checked");



        }

        private void button1_Click(object sender, EventArgs e)
        {

            var pesquisa = (this.ViewModel as LotacaoViewModel).ObterLotacoesPorNome(txtPesquisa.Text);

            dataGridView1.DataSource = new BindingList<LotacaoModel>(pesquisa.ToList()); 
           

           // LotacaoViewModel lotacaoVM = (LotacaoViewModel)lotacaoVMbindingSource.Current;

           // idTextBox.DataBindings.Add("Text", (LotacaoViewModel)lotacaoVMbindingSource.Current, "IdLotacao");

            //if (!IsModelValidate(currentLotacaoVM))
            //{
            //    MessageBox.Show(currentLotacaoVM.Descricao);
            //}

   
        }

        private void lotacaoVMbindingSource_CurrentChanged(object sender, EventArgs e)
        {
           // currentLotacaoVM = (LotacaoModel)lotacaoVMbindingSource.Current;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


    public class BaseForm1 : FormBase<LotacaoModel>
    {
        public BaseForm1() : this(new LotacaoViewModel()) { }

        public BaseForm1(LotacaoViewModel viewModel) : base(viewModel)
        {
        }
    }
}
