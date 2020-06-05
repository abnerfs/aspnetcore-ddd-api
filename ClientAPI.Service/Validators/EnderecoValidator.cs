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
                .OnAnyFailure(x =>
                {
                    throw new Exception("Endereço inválido");
                });

            RuleFor(x => x.Bairro)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(x => throw new Exception("Informe o bairro"));

            RuleFor(x => x.Cidade)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(x => throw new Exception("Informe uma cidade válida"));

            RuleFor(x => x.Estado)
                .NotNull()
                .NotEmpty()
                .Length(2)
                .OnAnyFailure(x => throw new Exception("Informe um estado válido"));

            RuleFor(x => x.Cep)
                .NotNull()
                .NotEmpty()
                .Length(8)
                .OnAnyFailure(x => throw new Exception("Informe uma CEP válido"));


            RuleFor(x => x.Logradouro)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(x => throw new Exception("Informe o logradouro do endereço"));

        }
    }
}
