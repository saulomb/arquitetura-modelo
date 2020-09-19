using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Infra.Repositorio.Dapper.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArquiteturaModelo.Infra.Contexto.Interfaces;
using Dommel;
using Dapper;

namespace ArquiteturaModelo.Infra.Repositorio.Dapper
{
    public class LotacaoRepositorio : Repositorio<Lotacao, byte>, ILotacaoRepositorio
    {
        public LotacaoRepositorio(IDapperContexto context)
            : base(context)
        {



        }

        public IEnumerable<Lotacao> ObterTodosAtivos()
        {
  
                return Conn.Select<Lotacao>(p => p.Inativa == false).OrderBy(o => o.Sigla);
      
        }

        public IEnumerable<Lotacao> ObterLotacaoesAtivaPorNome(string nome)
        {

            var nomes = nome.Split(' ').Where(n => n.Length >= 3);
            StringBuilder sqlNomes = new StringBuilder();

            foreach (var item in nomes)
            {
                sqlNomes.AppendFormat(" AND ((UndDescricao LIKE '%{0}%') OR (UndSigla LIKE '%{0}%')) ", item);
            }


            var sql = "SELECT  " +
                       " UndCod AS Id,  " +
                       " UndSigla AS Sigla, " +
                       " UndDescricao AS Descricao,  " +
                       " UndAcabou AS Acabou " +
                       //" UndResponsavel AS IdFuncionarioResponsavel " +
                       " FROM [dbo].[UnidadeCerb]   " +
                       " WHERE (UndAcabou = 0) " + sqlNomes.ToString();



                return Conn.Query<Lotacao>(sql);
     

        }

    }
}
