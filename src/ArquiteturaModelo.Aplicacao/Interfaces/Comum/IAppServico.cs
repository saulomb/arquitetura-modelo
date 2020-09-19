using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Aplicacao.Interfaces
{
   public interface IAppServico<TEntity, TKey> : IDisposable where TEntity : EntidadeBase<TKey>
    {
        TEntity ObterPorId(TKey id);
        IEnumerable<TEntity> ObterTodos();
        dynamic Adicionar(TEntity entity);
        bool Atualizar(TEntity entity);
        bool Deletar(TEntity entity);

         ValidationResult ValidationResult { get; }


        //IEnumerable<TEntity> ObterPor(object @where = null, object order = null);



    }
}
