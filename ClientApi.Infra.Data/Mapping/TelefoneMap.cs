using ClientAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApi.Infra.Data.Mapping
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefones");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Tel).IsRequired().HasMaxLength(9);
            builder.Property(x => x.DDD).IsRequired().HasMaxLength(2);
        }
    }
}
