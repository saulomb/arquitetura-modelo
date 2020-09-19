using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Interfaces.Servicos.Comum;
using System.Collections.Generic;

namespace ArquiteturaModelo.Dominio.Interfaces.Servicos
{
    public interface ILotacaoServico : IServico<Lotacao, byte>
    {

        IEnumerable<Lotacao> ObterTodosAtivos();
        IEnumerable<Lotacao> ObterLotacaoesAtivaPorNome(string nome);

    }
}
