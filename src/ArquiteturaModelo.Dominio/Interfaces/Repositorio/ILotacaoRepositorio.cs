using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using System.Collections.Generic;

namespace ArquiteturaModelo.Dominio.Interfaces.Repositorio
{
    public interface ILotacaoRepositorio : IRepositorio<Lotacao, byte>
    {

        IEnumerable<Lotacao> ObterTodosAtivos();


        IEnumerable<Lotacao> ObterLotacaoesAtivaPorNome(string nome);

    }
}
