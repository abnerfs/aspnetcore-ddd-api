using ClientAPI.Domain.Entities;
using ClientAPI.Infra.CrossCutting;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;

namespace ClientAPI.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public void CustomValidate(Cliente InstanceToValidate)
        {
            if (InstanceToValidate != null)
            {
                InstanceToValidate.CGC = Util.RemoveNonNumeric(InstanceToValidate.CGC);
            }

            this.ValidateAndThrow(InstanceToValidate, ruleSet: "*");
        }

        public ClienteValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure((x) => throw new ArgumentException("Cliente inválido"));

            var InformeNome = "Informe o nome";
            RuleFor(c => c.Nome)
                .NotNull().WithMessage(InformeNome)
                .NotEmpty().WithMessage(InformeNome);

            var InformeEmail = "Informe o e-mail";
            RuleFor(c => c.Email)
                .NotNull().WithMessage(InformeEmail)
                .NotEmpty().WithMessage(InformeEmail);

            var InformeEndereco = "Informe o endereço";
            RuleFor(c => c.Enderecos)
                .NotNull().WithMessage(InformeEndereco)
                .Must(x => x.Count() > 0).WithMessage(InformeEndereco)
                .ForEach(x => x.SetValidator(new EnderecoValidator()));

            var InformeTelefone = "Informe um telefone";
            RuleFor(c => c.Telefones)
                .NotNull().WithMessage(InformeTelefone)
                .Must(x => x.Count() > 0).WithMessage(InformeTelefone)
                .ForEach(x => x.SetValidator(new TelefoneValidator()));

            When(c => c.Tipo == TipoPessoa.Fisica, () =>
            {
                RuleFor(c => c.CGC)
                    .Must(c => ValidaCPF.IsCpf(c))
                    .WithMessage("Informe um CPF válido");
            });

            When(c => c.Tipo == TipoPessoa.Juridica, () =>
            {
                RuleFor(c => c.CGC)
                     .Must(c => ValidaCNPJ.IsCnpj(c))
                    .WithMessage("Informe um CNPJ válido");
            });
        }
    }
}
