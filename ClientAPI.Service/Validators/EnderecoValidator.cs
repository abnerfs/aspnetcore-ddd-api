using ClientAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAPI.Service.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentException("Endereço inválido"));

            RuleFor(x => x.Bairro)
                .NotNull()
                .WithMessage("Informe o bairro");


            var CidadeInvalida = "Informe uma cidade válida";
            RuleFor(x => x.Cidade)
                .NotNull().WithMessage(CidadeInvalida)
                .NotEmpty().WithMessage(CidadeInvalida);


            var EstadoInvalido = "Informe um estado válido";
            RuleFor(x => x.Estado)
                .NotNull().WithMessage(EstadoInvalido)
                .NotEmpty().WithMessage(EstadoInvalido)
                .Length(2).WithMessage(EstadoInvalido);


            var CepInvalido = "Informe uma CEP válido";
            RuleFor(x => x.Cep)
                .NotNull().WithMessage(CepInvalido)
                .NotEmpty().WithMessage(CepInvalido)
                .Length(8).WithMessage(CepInvalido);


            var LogradouroInvalido = "Informe o logradouro do endereço";
            RuleFor(x => x.Logradouro)
                .NotNull().WithMessage(LogradouroInvalido)
                .NotEmpty().WithMessage(LogradouroInvalido);
        }
    }
}
