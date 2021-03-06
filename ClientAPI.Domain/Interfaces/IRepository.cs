﻿using ClientAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAPI.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        T Get(int id);

        IList<T> List();
    }
}
