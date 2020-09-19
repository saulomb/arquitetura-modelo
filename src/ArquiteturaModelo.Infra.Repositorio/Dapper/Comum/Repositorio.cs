using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using ArquiteturaModelo.Infra.Contexto.Mapeamento;
using System;
using System.Collections.Generic;
using System.Data;
//using DapperExtensions;
using Dommel;
using ArquiteturaModelo.Infra.Contexto;
using System.Linq;
using System.Data.SqlClient;
using ArquiteturaModelo.Dominio.Entidades;

namespace ArquiteturaModelo.Infra.Repositorio.Dapper.Comum
{
    public class Repositorio<TEntity, TKey> : IRepositorio<TEntity, TKey>, IDisposable where TEntity : EntidadeBase<TKey>
    {

        public IDbConnection Conn { get; set; }

        //public readonly IDapperContexto _contexto;
        
        public Repositorio(IDapperContexto context)
        {
            //_contexto = context;
            Conn = context.Connection;
           // RegisterMappings.Register();
        }


       public dynamic Adicionar(TEntity entity, IDbTransaction transaction)
        {

            if (entity == null)
                return null;

            return Conn.Insert(entity, transaction);
       
            
      
        }

        public bool Atualizar(TEntity entity, IDbTransaction transaction)
        {
            return entity != null && Conn.Update(entity, transaction);
        }

        public bool Deletar(TEntity entity, IDbTransaction transaction)
        {
            return entity != null && Conn.Delete(entity, transaction);
        }

        public TEntity ObterPorId(TKey id)
        {

            //using (var db = Conn )
            //{
            //    return db.Get<TEntity>(id);
            //}

            return Conn.Get<TEntity>(id);

        }

        public IEnumerable<TEntity> ObterTodos()
        {

            //using (var db = Conn)
            //{
            //    return db.GetAll<TEntity>();
            //}


            return Conn.GetAll<TEntity>();

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
