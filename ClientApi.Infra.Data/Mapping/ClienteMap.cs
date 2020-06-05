using ClientAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApi.Infra.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DtCadastro).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.CGC).HasMaxLength(11);

            builder.HasMany(x => x.Telefones);
            builder.HasMany(x => x.Enderecos);
        }
    }
}
