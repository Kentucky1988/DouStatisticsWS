using System.Collections.Generic;
using System.Data.Entity;
using DouStatistics.DAL;
using DouStatistics.DAL.Interfaces;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class SearchKeywordsDto
    {
        private readonly IRepository<KeyWords> _dB;

        public SearchKeywordsDto(DbContext dbContext)
        {
            _dB = new GenericRepository<KeyWords>(dbContext);
        }

        ///<summary>
        /// Получить список ключевых слов 
        ///</summary>
        public List<KeyWords> GetAll()
        {
            return _dB.GetAll();
        }
    }
}
