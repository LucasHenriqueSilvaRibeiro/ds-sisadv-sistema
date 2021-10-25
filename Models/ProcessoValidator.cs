using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SisAdv.Models
{
    class ProcessoValidator : AbstractValidator<Processo>
    {
        public ProcessoValidator()
        {
            RuleFor(x => x.Advogado).NotEmpty().WithMessage("O `Advogado` é Obrigatório. Favor Preencher");
            RuleFor(x => x.Cliente).NotEmpty().WithMessage("O `Cliente` é Obrigatório. Favor Preencher");
            RuleFor(x => x.DataProcesso).NotEmpty().WithMessage("O campo `Data de Início` é Obrigatório. Favor Preencher");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O campo `Descrição` é Obrigatório e importante. Favor Preencher");
            RuleFor(x => x.Status).NotEmpty().WithMessage("O campo `Status` é Obrigatório e importante. Favor Preencher");
        }
    }
}
