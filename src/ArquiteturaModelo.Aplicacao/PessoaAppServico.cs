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
    public class PessoaAppServico : AppServico, IPessoaAppServico
    {
        private readonly IPessoaServico _servico;
        private readonly IUnitOfWork _uow;

        public PessoaAppServico(IPessoaServico servico
            , IUnitOfWork uow
            )
        {
            _servico = servico;
            _uow = uow;

        }

        public dynamic Adicionar(Pessoa pessoa)
        {
            ///ValidationResult.Add(_servico.Adicionar(lotacao, _uow.BeginTransaction()));

            // ValidationResult.Add(lotacao.ValidationResult);

            //if (!lotacao.IsValid)
            //    return lotacao.ValidationResult;
            ValidationResult.Clear();



            var lotacaoAdicionada = _servico.Adicionar(pessoa, _uow.BeginTransaction());
            ValidationResult.Add(_servico.ValidationResult);
            
            if (_servico.ValidationResult.IsValid)
                _uow.Commit();
            else
                _uow.Rollback();

            return lotacaoAdicionada;

        }

        public bool Atualizar(Pessoa pessoa)
        {
            ValidationResult.Clear();

            var atualizou = _servico.Atualizar(pessoa, _uow.BeginTransaction());
            ValidationResult.Add(_servico.ValidationResult);
            if (_servico.ValidationResult.IsValid) _uow.Commit();
            return atualizou;
        }

        public bool Deletar(Pessoa pessoa)
        {
            ValidationResult.Clear();
            var deletou = _servico.Deletar(pessoa, _uow.BeginTransaction());
            ValidationResult.Add(_servico.ValidationResult);
            if (_servico.ValidationResult.IsValid) _uow.Commit();
            return deletou;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //public IEnumerable<Pessoa> ObterLotacaoesAtivaPorNome(string nome)
        //{
        //    return _servico.ObterLotacaoesAtivaPorNome(nome);
        //}

        public Pessoa ObterPorId(int id)
        {
            return _servico.ObterPorId(id);
        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            //return _servico.ObterTodos(_uow.BeginTransaction());
            return _servico.ObterTodos();
        }

        //public IEnumerable<Lotacao> ObterTodosAtivos()
        //{
        //    return _servico.ObterTodosAtivos();
        //}

        // public IEnumerable<Lotacao> ObterPor(object @where = null, object order = null)
        //{
        //    return _servico.ObterPor(@where);
        //}

    }
}
