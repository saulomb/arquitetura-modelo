using ArquiteturaModelo.Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Validacoes;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;

namespace ArquiteturaModelo.Aplicacao
{
    public class LotacaoAppServico : AppServico, ILotacaoAppServico
    {
        private readonly ILotacaoServico _servico;
        private readonly IUnitOfWork _uow;

        public LotacaoAppServico(ILotacaoServico servico
            , IUnitOfWork uow
            )
        {
            _servico = servico;
            _uow = uow;

        }

        public dynamic Adicionar(Lotacao lotacao)
        {
            ///ValidationResult.Add(_servico.Adicionar(lotacao, _uow.BeginTransaction()));

            // ValidationResult.Add(lotacao.ValidationResult);

            //if (!lotacao.IsValid)
            //    return lotacao.ValidationResult;
            ValidationResult.Clear();



            var lotacaoAdicionada = _servico.Adicionar(lotacao, _uow.BeginTransaction());
            ValidationResult.Add(_servico.ValidationResult);
            
            if (_servico.ValidationResult.IsValid)
                _uow.Commit();
            else
                _uow.Rollback();

            return lotacaoAdicionada;

        }

        public bool Atualizar(Lotacao lotacao)
        {
            ValidationResult.Clear();

            var atualizou = _servico.Atualizar(lotacao, _uow.BeginTransaction());
            ValidationResult.Add(_servico.ValidationResult);
            if (_servico.ValidationResult.IsValid) _uow.Commit();
            return atualizou;
        }

        public bool Deletar(Lotacao lotacao)
        {
            ValidationResult.Clear();
            var deletou = _servico.Deletar(lotacao, _uow.BeginTransaction());
            ValidationResult.Add(_servico.ValidationResult);
            if (_servico.ValidationResult.IsValid) _uow.Commit();
            return deletou;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Lotacao> ObterLotacaoesAtivaPorNome(string nome)
        {
            return _servico.ObterLotacaoesAtivaPorNome(nome);
        }

        public Lotacao ObterPorId(byte id)
        {
            return _servico.ObterPorId(id);
        }

        public IEnumerable<Lotacao> ObterTodos()
        {
            //return _servico.ObterTodos(_uow.BeginTransaction());
            return _servico.ObterTodos();
        }

        public IEnumerable<Lotacao> ObterTodosAtivos()
        {
            return _servico.ObterTodosAtivos();
        }

        // public IEnumerable<Lotacao> ObterPor(object @where = null, object order = null)
        //{
        //    return _servico.ObterPor(@where);
        //}

    }
}
