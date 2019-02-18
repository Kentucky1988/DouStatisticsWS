using System.Collections.Generic;
using DouStatistics.DAL;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class SearchKeywordsDto
    {
        private GenericRepository<KeyWords> _dB;

        public SearchKeywordsDto()
        {
            _dB = new GenericRepository<KeyWords>();
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
