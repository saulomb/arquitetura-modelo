using ArquiteturaModelo.Dominio.Interfaces.Especificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Dominio.Entidades.Especificacao.Produtos
{
    public class LotacaoDescricaoNaoPodeSerNuloOuEmBrancoSpecification : ISpecification<Lotacao>
    {
        public bool IsSatisfiedBy(Lotacao produto)
        {
            return !String.IsNullOrEmpty(produto.Descricao) && !String.IsNullOrWhiteSpace(produto.Descricao);
        }
    }
}
