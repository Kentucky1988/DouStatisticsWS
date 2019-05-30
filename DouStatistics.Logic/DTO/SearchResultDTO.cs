using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DouStatistics.DAL;
using DouStatistics.DAL.Interfaces;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class SearchResultDTO
    {
        private readonly IRepository<ResultsSearch> _dB;

        public SearchResultDTO(DbContext dbContext)
        {
            _dB = new GenericRepository<ResultsSearch>(dbContext);
        }

        public SearchResultDTO(IRepository<ResultsSearch> db)
        {
            _dB = db;
        }

        ///<summary>
        /// Сохранить результат поиска
        ///</summary>
        public void SaveResult(ResultsSearch result)
        {
            _dB.Create(result);
        }

        ///<summary>
        /// Получить все записи из таблицы
        ///</summary>
        public List<ResultsSearch> GetAll()
        {
            return _dB.GetAll();
        }

       /// <summary>
        /// Получить дату последней записи в таблице Search_results
        /// </summary>
        public DateTime GetLastRecordDate()
        {
            return _dB.GetAll().Max(c => c.Date);
        }
    }
}
