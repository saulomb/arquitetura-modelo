using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;
using ArquiteturaModelo.Dominio.Servicos.Comum;
using System.Collections.Generic;

namespace ArquiteturaModelo.Dominio.Servicos
{
    public class LotacaoServico : Servico<Lotacao, byte>, ILotacaoServico
    {

        private readonly ILotacaoRepositorio lotacaoRepositorio;

        public LotacaoServico(ILotacaoRepositorio repositorio)
            : base(repositorio)
        {
            lotacaoRepositorio = repositorio;
        }

        public IEnumerable<Lotacao> ObterLotacaoesAtivaPorNome(string nome)
        {
            return lotacaoRepositorio.ObterLotacaoesAtivaPorNome(nome);
        }

        public IEnumerable<Lotacao> ObterTodosAtivos()
        {
            return lotacaoRepositorio.ObterTodosAtivos();
        }
    }
}
