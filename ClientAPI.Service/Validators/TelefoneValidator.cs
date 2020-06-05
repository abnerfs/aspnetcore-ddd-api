using ClientAPI.Domain.Entities;
using ClientAPI.Infra.CrossCutting;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClientAPI.Service.Validators
{
    public class TelefoneValidator : AbstractValidator<Telefone>
    {
        public override ValidationResult Validate(ValidationContext<Telefone> context)
        {
            if(context.InstanceToValidate != null)
            {
                context.InstanceToValidate.Tel = Util.RemoveNonNumeric(context.InstanceToValidate.Tel);
            }
            return base.Validate(context);
        }

        public TelefoneValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Telefone inválido");

            var InformeTelefone = "Informe o telefone";

            RuleFor(x => x.Tel)
                .NotNull().WithMessage(InformeTelefone)
                .NotEmpty().WithMessage(InformeTelefone);

            When(x => x.Tipo == TipoTelefone.Celular, () =>
            {
                RuleFor(x => x.Tel)
                .Length(9)
                .WithMessage("Informe um número de celular com 9 dígitos");
            });

            When(x => x.Tipo == TipoTelefone.Fixo, () => { 
                RuleFor(x => x.Tel)
                .Length(8)
                .WithMessage("Informe um telefone fixo com 8 digitos");
            });


            var InformeDDD = "Informe o DDD";

            RuleFor(x => x.DDD)
                .NotNull().WithMessage(InformeDDD)
                .NotEmpty().WithMessage(InformeDDD)
                .Length(2).WithMessage("DDD Inválido");
        }
    }
}
