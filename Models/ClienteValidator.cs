using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SisAdv.Models
{
    class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo `Nome` é Obrigatório. Favor Preencher");
            RuleFor(x => x.Rg).NotEmpty().WithMessage("O campo `Advogado` é Obrigatório. Favor Preencher");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Algum `Tipo de Serviço` é Obrigatório. Favor Preencher");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("O campo `Data` é Obrigatório. Favor Preencher");

            
            //CÓDIGO DE CPF TAMBÉM
            RuleFor(x => x.Cpf).NotEqual("___.___.___-__").WithMessage("O campo `CPF` é obrigatório. Favor Preencher");
            RuleFor(x => x.Cpf).Must(CPFValidator).WithMessage("CPF inválido");

            //implementar o resto
        }
        public bool CPFValidator(string cpf)
        {
            return true;
        }
        
    }
}
