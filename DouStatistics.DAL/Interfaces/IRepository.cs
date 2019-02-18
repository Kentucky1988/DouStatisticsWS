using System;

namespace DouStatistics.DAL.Interfaces
{
    using System.Collections.Generic;
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T model);
        void Update(T model);
        void Delete(T model);
    }
}

