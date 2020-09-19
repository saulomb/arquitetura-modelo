using ArquiteturaModelo.Dominio.Entidades;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio;
using ArquiteturaModelo.Dominio.Interfaces.Repositorio.Comum;
using ArquiteturaModelo.Dominio.Interfaces.Servicos;
using ArquiteturaModelo.Dominio.Servicos.Comum;
using System.Collections.Generic;

namespace ArquiteturaModelo.Dominio.Servicos
{
    public class PessoaServico : Servico<Pessoa, int>, IPessoaServico
    {

        private readonly IPessoaRepositorio pessoaRepositorio;

        public PessoaServico(IPessoaRepositorio repositorio)
            : base(repositorio)
        {
            pessoaRepositorio = repositorio;
        }


    }
}
