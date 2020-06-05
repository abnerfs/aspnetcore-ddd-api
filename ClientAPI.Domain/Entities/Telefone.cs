using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAPI.Domain.Entities
{
    public enum TipoTelefone
    {
        Fixo,
        Celular
    }

    public class Telefone : BaseEntity
    {
        public TipoTelefone Tipo { get; set; }
        public string Tel { get; set; }
        public string DDD { get; set; }
    }
}
