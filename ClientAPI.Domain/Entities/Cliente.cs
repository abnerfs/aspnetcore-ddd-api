using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ClientAPI.Domain.Entities
{
    public enum TipoPessoa
    {
        Fisica,
        Juridica
    }

    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DtCadastro { get; set; }
        public string Email { get; set; }
        public TipoPessoa Tipo { get; set; }
        public string CGC { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; } = new List<Telefone>();
        public IEnumerable<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}
