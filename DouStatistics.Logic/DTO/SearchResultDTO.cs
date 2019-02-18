using System;
using System.Collections.Generic;
using System.Linq;
using DouStatistics.DAL;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class SearchResultDTO
    {
        private GenericRepository<ResultsSearch> _dB;

        public SearchResultDTO()
        {
            _dB = new GenericRepository<ResultsSearch>();
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

        ///<summary>
        /// Удалить все записи из таблицы
        ///</summary>
        public void DeleteAll()
        {
            var table = _dB.GetAll();

            foreach (var record in table)
            {
                var rec = _dB.Get(record.Id);
                _dB.Delete(rec);
            }
        }

        /// <summary>
        /// Получить дату последней записи в таблице Search_results
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastRecordDate()
        {
            return _dB.GetAll().Max(c => (DateTime?)c.Date) ?? default(DateTime);
        }
    }
}
