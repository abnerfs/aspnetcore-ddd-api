using ClientApi.Infra.Data.Context;
using ClientAPI.Domain.Entities;
using ClientAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApi.Infra.Data.Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private SqlContext context;
        public ClienteRepository(SqlContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Clientes.Remove(Get(id));
            context.SaveChanges();
        }

        public void Insert(Cliente obj)
        {
            context.Clientes.Add(obj);
            context.SaveChanges();
        }

        public Cliente Get(int id)
        {
            return context.Clientes
                .Include(x => x.Telefones)
                .Include(x => x.Enderecos)
                .SingleOrDefault(x => x.id == id);
        }

        public IList<Cliente> List()
        {
            return context.Clientes
               .Include(x => x.Telefones)
               .Include(x => x.Enderecos)
               .ToList();
        }

        public void Update(Cliente obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
