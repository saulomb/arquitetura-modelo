using ArquiteturaModelo.Dominio.Entidades.Especificacao.Produtos;
using ArquiteturaModelo.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Dominio.Entidades.Validacao.Produtos
{
    public class LotacaoEstaConsistenteValidation : Validation<Lotacao>
    {
        public LotacaoEstaConsistenteValidation()
        {
            AddRule(new ValidationRule<Lotacao>(new LotacaoDescricaoNaoPodeSerNuloOuEmBrancoSpecification(), "A Descrição da Lotação não pode ser nula ou em branco."));
        }
    }
}
