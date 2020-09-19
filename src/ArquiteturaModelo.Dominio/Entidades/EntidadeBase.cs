using ArquiteturaModelo.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Dominio.Entidades
{
    public abstract class EntidadeBase<Tkey>
    {
        private readonly ValidationResult validationResult;

        protected EntidadeBase()
        {
            validationResult = new ValidationResult();
        }

        public Tkey Id { get; set; }


        public ValidationResult Validation { get { return validationResult; }  }

        public abstract bool EhValido();






    }
}
