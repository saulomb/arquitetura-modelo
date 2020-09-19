using ArquiteturaModelo.Apresentacao.WF2.BaseModel;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Apresentacao.WF2.Models
{
    public class LotacaoModel: Model 
    {


        [Notify]
        public byte IdLotacao
        {
            get { return base.GetValue<byte>("IdLotacao"); }
            set
            {
                base.SetValue("IdLotacao", value);
                //if (this.firstname != value) {
                //    this.firstname = value;
                //    base.OnPropertyChanged(() => this.FirstName);
                //}
            }
        }

        [Required(ErrorMessage = "Descricao é como obrigatório")]
        [Notify]
        public string Descricao
        {
            get { return base.GetValue<string>("Descricao"); }
            set
            {
                base.SetValue("Descricao", value);
                //if (this.firstname != value) {
                //    this.firstname = value;
                //    base.OnPropertyChanged(() => this.FirstName);
                //}
            }
        }

        [Required(ErrorMessage = "Sigla é como obrigatório")]
        [Notify]
        public string Sigla
        {
            get { return base.GetValue<string>("Sigla"); }
            set
            {
                base.SetValue("Sigla", value);
            }
        }
        [Notify]
        public bool Inativa
        {
            get { return base.GetValue<bool>("Inativa"); }
            set
            {
                base.SetValue("Inativa", value);
            }
        }

        public Lotacao ModelToDominio()
        {
            return new Lotacao
            {
                Id = this.IdLotacao,
                Descricao = this.Descricao,
                Sigla = this.Sigla,
                Inativa = this.Inativa
            };
        }

        public void DominioToModel(Lotacao dominio)
        {
            this.IdLotacao = dominio.Id;
            this.Descricao = dominio.Descricao;
            this.Sigla = dominio.Sigla;
            this.Inativa = dominio.Inativa;
        }




    }
}
