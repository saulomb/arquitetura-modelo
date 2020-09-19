using ArquiteturaModelo.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Aplicacao
{
    public class AppServico
    {
        public AppServico()
        {
            ValidationResult = new ValidationResult();
        }
        public ValidationResult ValidationResult { get; set; }
    }
}
