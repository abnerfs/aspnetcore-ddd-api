using ClientAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClientAPI.Service.Validators
{
    public class TelefoneValidator : AbstractValidator<Telefone>
    {
        public TelefoneValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("Telefone inválido");

            RuleFor(x => x.Tel)
                .NotNull().WithMessage("Informe o telefone")
                .NotEmpty().WithMessage("Informe o telefone");

            RuleFor(x => x.DDD)
                .NotNull().WithMessage("Informe o DDD")
                .NotEmpty().WithMessage("Informe o DDD")
                .MinimumLength(2).WithMessage("DDD Inválido")
                .MaximumLength(2).WithMessage("DDD Inválido");
        }
    }
}
