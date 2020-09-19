using ArquiteturaModelo.Dominio.Entidades.Validacao.Produtos;
using ArquiteturaModelo.Dominio.Validacoes;

namespace ArquiteturaModelo.Dominio.Entidades
{
    /// <summary>
    /// Produto
    /// </summary>
    public class Lotacao:EntidadeBase<byte>
    {




        /// <summary>
        /// Descricao  da Lotacao
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Sigla  da Lotacao
        /// </summary>
        public string Sigla { get; set; }
        /// <summary>
        /// Indica se lotação está inativa
        /// </summary>
        public bool Inativa { get; set; }

        /// <summary>
        /// Validação e consistência da entidade 
        /// </summary>

        /// <summary>
        /// Retorno da Validação
        /// </summary>
        public override bool EhValido()
        {
            Validation.Clear();
            Validation.Add(new LotacaoEstaConsistenteValidation().Valid(this));
            return Validation.IsValid;
        }
        
        
    }
}

