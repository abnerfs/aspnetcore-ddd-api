using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientApi.Infra.Data.Context;
using ClientApi.Infra.Data.Repository;
using ClientAPI.Domain.Entities;
using ClientAPI.Service.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;

namespace ClientAPI.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];
            services.AddSqlite(connection);
            services.AddScoped(x => new Repository<Cliente>(x.GetService<SqlContext>()));
            services.AddScoped(x => new Repository<Endereco>(x.GetService<SqlContext>()));
            services.AddScoped(x => new Repository<Telefone>(x.GetService<SqlContext>()));
            services.AddScoped(x => new ClienteValidator());
            services.AddScoped(x => new TelefoneValidator());
            services.AddScoped(x => new EnderecoValidator());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
