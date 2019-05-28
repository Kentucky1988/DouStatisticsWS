using System.Data.Entity;
using DouStatistics.DAL;
using DouStatistics.DAL.Interfaces;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class WorkingServiceDTO
    {
        private readonly IRepository<WorkService> _dB;

        public WorkingServiceDTO(DbContext dbContext)
        {
            _dB = new GenericRepository<WorkService>(dbContext);
        }

        /// <summary>
        /// Добавить результаты работы службы
        /// </summary>
        public void Save(WorkService result)
        {
            _dB.Create(result);
        }
    }
}
