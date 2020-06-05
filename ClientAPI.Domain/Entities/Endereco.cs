using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAPI.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public bool Principal { get; set; }
    }
}
