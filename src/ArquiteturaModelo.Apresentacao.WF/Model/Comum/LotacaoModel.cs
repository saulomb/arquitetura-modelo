using ArquiteturaModelo.Apresentacao.WF.Model.Base;
using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Apresentacao.WF.Model.Comum
{
    public class LotacaoModel: BaseModel
    {

        private byte _idLotacao;
        private string _descricao;
        private string _sigla;
        private bool _inativa;



        [Required(ErrorMessage ="Teste Id")]
        [Range(1, 100)]
        public byte IdLotacao 
        { get { return _idLotacao; } 
          set
            {
                SetField(ref _idLotacao, value);
            } 
        }
        /// <summary>
        /// Descricao  da Lotacao
        /// </summary>
        [Required]
        [StringLength(40)]
        // [RegularExpression("w+")]
        public string Descricao 
        { get { return _descricao;  }
            set
            {
                SetField(ref _descricao, value);
            } 
        }
        /// <summary>
        /// Sigla  da Lotacao
        /// </summary>
        [Required()]
        [StringLength(25, MinimumLength = 2)]
        public string Sigla 
        { get { return _sigla; }
            set
            {
                SetField(ref _sigla, value);
            } 
        }
        /// <summary>
        /// Indica se lotação está inativa
        /// </summary>
        public bool Inativa
        { get { return _inativa; }
          set
            {
                SetField(ref _inativa, value);
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
