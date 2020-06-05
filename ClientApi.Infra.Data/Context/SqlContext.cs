using ClientApi.Infra.Data.Mapping;
using ClientAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApi.Infra.Data.Context
{
    public static class ContextExtension
    {
        public static IServiceCollection AddSqlite(this IServiceCollection services, string connectionString, string migrationAssembly)
        {
            return services.AddDbContext<SqlContext>(options =>
                options.UseSqlite(connectionString, b => b.MigrationsAssembly(migrationAssembly))
            ); 
        }
    }

    public class SqlContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Telefone>(new TelefoneMap().Configure);
            modelBuilder.Entity<Endereco>(new EnderecoMap().Configure);
        }
    }
}
