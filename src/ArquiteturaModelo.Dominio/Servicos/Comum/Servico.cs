using System;
using System.Collections.Generic;
using System.Data;
using ArquiteturaModelo.Dominio.Interfaces.Servicos.Comum;
using ArquiteturaModelo.Dominio.Validacoes;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using ArquiteturaModelo.Dominio.Interfaces.Validacoes;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Dominio.Entidades;

namespace ArquiteturaModelo.Dominio.Servicos.Comum
{
    public class Servico<TEntity, TKey> : IServico<TEntity, TKey> where TEntity : EntidadeBase<TKey>
    {
        protected readonly IRepositorio<TEntity, TKey> _repositorio;
        private  readonly ValidationResult _validationResult;

        public Servico(IRepositorio<TEntity, TKey> repositorio)
        {
            _repositorio = repositorio;
            // _validationResult = (TEntity as EntidadeBase<TKey>).Validation;
            _validationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult
        {
            get { return _validationResult; } 
            //set { _validationResult = value; }
        }

     


        public dynamic Adicionar(TEntity entity, IDbTransaction transaction)
        {
            _validationResult.Clear();


            if (!entity.EhValido())
            {
                _validationResult.Add(entity.Validation);
                return null;
            }

            var adicionou = _repositorio.Adicionar(entity, transaction);
            if (adicionou == null)
                 _validationResult.Add("A Entidade que você está tentando gravar está nula, por favor tente novamente!" + entity + "Adicionar");

            return adicionou;
        }

        public bool Atualizar(TEntity entity, IDbTransaction transaction)
        {
            _validationResult.Clear();

            if (!entity.EhValido())
            {
                _validationResult.Add(entity.Validation);
                return false;
            }
            var atualizar = _repositorio.Atualizar(entity, transaction);
            if (!atualizar)
               _validationResult.Add("A Entidade que você está tentando atualizar está nula, por favor tente novamente! Nome: " + entity + "Atualizar");
               
            
               
            return atualizar; ;
        }

        public bool Deletar(TEntity entity, IDbTransaction transaction)
        {
            _validationResult.Clear();

            var deletou = _repositorio.Deletar(entity, transaction);
            if (!deletou)
                 _validationResult.Add("A Entidade que você está tentando deletar está nula, por favor tente novamente! Nome: " + entity + "Deletar");
            return deletou;
        }

         public TEntity ObterPorId(TKey id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }



        //public IEnumerable<TEntity> ObterPor(object @where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null)
        //{
        //    return _repositorio.ObterPor(@where);
        //}
    }
}
