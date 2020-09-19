using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Validacoes;
using System.Collections.Generic;
using System.Data;

namespace ArquiteturaModelo.Dominio.Interfaces.Servicos.Comum
{
    public interface IServico<TEntity,TKey> where TEntity : EntidadeBase<TKey>
    {
        dynamic Adicionar(TEntity entity, IDbTransaction transaction);
        bool Atualizar(TEntity entity, IDbTransaction transaction);
        bool Deletar(TEntity entity, IDbTransaction transaction);
        TEntity ObterPorId(TKey id);
        IEnumerable<TEntity> ObterTodos();
        ValidationResult ValidationResult { get; }

        //IEnumerable<TEntity> ObterPor(object where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null);
    }
}
