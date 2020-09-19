using ArquiteturaModelo.Dominio.Entidades.Validacao.Produtos;
using ArquiteturaModelo.Dominio.Validacoes;
using System;

namespace ArquiteturaModelo.Dominio.Entidades
{

    public class Pessoa:EntidadeBase<int>
    {




        public string Nome { get; set; }

        public string NomeCompleto { get; set; }

        public char Tipo { get; set; }

        public DateTime DataCadastro { get; set; }





        /// <summary>
        /// Retorno da Validação
        /// </summary>
        public override bool EhValido()
        {
            //Validation.Clear();
            //Validation.Add(new LotacaoEstaConsistenteValidation().Valid(this));
            //return Validation.IsValid;
            return true;
        }
        
        
    }
}

