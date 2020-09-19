using ArquiteturaModelo.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Infra.Contexto.Mapeamento
{

    public class LotacaoMap : DommelEntityMap<Lotacao>
    {
        public LotacaoMap()
        {
            ToTable("UnidadeCerb");
            Map(x => x.Id).ToColumn("UndCod").IsKey().IsIdentity();
            Map(x => x.Descricao).ToColumn("UndDescricao");
            Map(x => x.Sigla).ToColumn("UndSigla");
            Map(x => x.Inativa).ToColumn("UndAcabou");
        }
    }
}
