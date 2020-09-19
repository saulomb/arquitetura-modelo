
using ArquiteturaModelo.Apresentacao.WF3.BaseModel;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Apresentacao.WF3.Models
{
    public class PessoaModel : Model 
    {


       // [Notify]
        public int IdPessoa
        {
            get { return base.GetValue<byte>("IdPessoa"); }
            set
            {
                base.SetValue("IdPessoa", value);
                //if (this.firstname != value) {
                //    this.firstname = value;
                //    base.OnPropertyChanged(() => this.FirstName);
                //}
            }
        }

        [Required(ErrorMessage = "Nome é como obrigatório")]
        //[Notify]
        public string Nome
        {
            get { return base.GetValue<string>("Nome"); }
            set
            {
                base.SetValue("Nome", value);
                //if (this.firstname != value) {
                //    this.firstname = value;
                //    base.OnPropertyChanged(() => this.FirstName);
                //}
            }
        }

        [Required(ErrorMessage = "NomeCompleto é como obrigatório")]
        //[Notify]
        public string NomeCompleto
        {
            get { return base.GetValue<string>("NomeCompleto"); }
            set
            {
                base.SetValue("NomeCompleto", value);
            }
        }
        //[Notify]
        public char Tipo
        {
            get { return base.GetValue<char>("Tipo"); }
            set
            {
                base.SetValue("Tipo", value);
            }
        }

        public Pessoa ModelToDominio()
        {
            return new Pessoa
            {
                Id = this.IdPessoa,
                Nome = this.Nome,
                NomeCompleto = this.NomeCompleto,
                Tipo = this.Tipo
            };
        }

        public void DominioToModel(Pessoa dominio)
        {
            this.IdPessoa = dominio.Id;
            this.Nome = dominio.Nome;
            this.NomeCompleto = dominio.NomeCompleto;
            this.Tipo = dominio.Tipo;
        }




    }
}
