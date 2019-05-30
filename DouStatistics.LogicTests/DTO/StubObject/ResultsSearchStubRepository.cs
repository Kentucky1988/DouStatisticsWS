using DouStatistics.DAL;
using DouStatistics.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DouStatistics.LogicTests.DTO.StubObject
{
    class ResultsSearchStubRepository<T> : IRepository<T> where T : ResultsSearch
    {
        public void Create(T model)
        {
            throw new NotImplementedException();
        }

        public void Delete(T model)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            var list = new List<ResultsSearch>();
            list.Add(new ResultsSearch { Id = 1, KeyWordId = 1, Amount = 10, Date = new DateTime(2019, 01, 01, 00, 01, 00) });
            list.Add(new ResultsSearch { Id = 1, KeyWordId = 1, Amount = 10, Date = new DateTime(2019, 01, 02, 00, 01, 00) });
            list.Add(new ResultsSearch { Id = 1, KeyWordId = 1, Amount = 10, Date = new DateTime(2019, 01, 03, 00, 01, 00) });

            return list as List<T>;
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
