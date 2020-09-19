using ArquiteturaModelo.Aplicacao.Interfaces;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquiteturaModelo.Apresentacao.WF
{
    public partial class Form1 : Form 
    {
        private readonly ILotacaoAppServico _appServico;

        public Form1(ILotacaoAppServico appServico)
        {
            _appServico = appServico;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = _appServico.ObterLotacaoesAtivaPorNome(txtPesquisa.Text).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lotacao = new Lotacao { Descricao = txtDescricao.Text, Sigla = txtSigla.Text };
            
            if ((!lotacao.EhValido()) && (lotacao.Validation.Errors.Any()))
            {
                foreach (var error in lotacao.Validation.Errors)
                {
                    MessageBox.Show(error.Message, "Erro");

                }
                return;
            }
            
          
            
            try
            {
               var idLotacao = _appServico.Adicionar(lotacao);
               var localizaLotacao = _appServico.ObterPorId((byte)idLotacao);
                if (localizaLotacao != null)
                    txtId.Text = localizaLotacao.Id.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu erro ao incluir a Lotacao!", "Erro");
            }
            
            
            
           // foreach (var error in _appServico.ValidationResult.Errors)
           // {
           //     MessageBox.Show(error.Message, "Erro");

           // }
           //if (!_appServico.ValidationResult.IsValid) return;

               










        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _appServico.ObterTodos();
        }
    }
}
