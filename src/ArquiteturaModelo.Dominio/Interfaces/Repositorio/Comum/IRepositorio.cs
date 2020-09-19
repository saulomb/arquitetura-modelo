using ArquiteturaModelo.Dominio.Entidades;
using System.Collections.Generic;
using System.Data;

namespace ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepositorio<TEntity, TKey> where TEntity : EntidadeBase<TKey>
    {
        dynamic Adicionar(TEntity entity, IDbTransaction transaction);
        bool Atualizar(TEntity entity, IDbTransaction transaction);
        bool Deletar(TEntity entity, IDbTransaction transaction);
        TEntity ObterPorId(TKey id);
        IEnumerable<TEntity> ObterTodos();
        //IEnumerable<TEntity> ObterPor(object where = null, object order = null);
        
    }
}
