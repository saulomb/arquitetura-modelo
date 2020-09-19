﻿using ArquiteturaModelo.Infra.Contexto.Mapeamento;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Infra.Contexto
{
    public static class RegisterMappings
    {
        public static void Register()
        {

            
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new LotacaoMap());
                config.AddMap(new PessoaMap());
                config.ForDommel();
            });
        }
    }
}
