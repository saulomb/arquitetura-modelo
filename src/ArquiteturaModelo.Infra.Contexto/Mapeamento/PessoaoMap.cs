using ArquiteturaModelo.Dominio.Entidades;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Infra.Contexto.Mapeamento
{

    public class PessoaMap : DommelEntityMap<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoa");
            Map(x => x.Id).ToColumn("PessoaCod").IsKey().IsIdentity();
            Map(x => x.Nome).ToColumn("PessoaNm");
            Map(x => x.NomeCompleto).ToColumn("PessoaNmCompleto");
            Map(x => x.Tipo).ToColumn("Pessoa");
            Map(x => x.DataCadastro).ToColumn("DtCadastro");
        }
    }
}
