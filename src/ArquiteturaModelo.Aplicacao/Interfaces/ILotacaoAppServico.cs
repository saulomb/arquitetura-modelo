using ArquiteturaModelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Aplicacao.Interfaces
{
    public interface ILotacaoAppServico : IAppServico<Lotacao, byte>
    {

        IEnumerable<Lotacao> ObterTodosAtivos();
        IEnumerable<Lotacao> ObterLotacaoesAtivaPorNome(string nome);

    }
}
