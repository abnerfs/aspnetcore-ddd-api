using ClientAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Linq;

namespace ClientAPI.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure((x) =>
                {
                    throw new ArgumentException("Cliente inválido");
                });

            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Informe o nome")
                .NotEmpty().WithMessage("Informe o nome");

            RuleFor(c => c.Email)
                .NotNull().WithMessage("Informe o e-mail")
                .NotEmpty().WithMessage("Informe o e-mail");

            RuleFor(c => c.Enderecos)
                .NotNull().WithMessage("Informe o endereço")
                .Must(x => x.Count() > 0).WithMessage("Informe um endereço")
                .ForEach(x => x.SetValidator(new EnderecoValidator()));

            RuleFor(c => c.Telefones)
                .NotNull().WithMessage("Informe um telefone")
                .Must(x => x.Count() > 0).WithMessage("Informe um telefone")
                .ForEach(x => x.SetValidator(new TelefoneValidator()));
        }
    }
}
