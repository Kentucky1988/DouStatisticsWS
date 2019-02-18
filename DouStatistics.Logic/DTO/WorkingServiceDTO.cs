using DouStatistics.DAL;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class WorkingServiceDTO
    {
        private GenericRepository<WorkService> _dB;

        public WorkingServiceDTO()
        {
            _dB = new GenericRepository<WorkService>();
        }

        /// <summary>
        /// Добавить результаты работы службы
        /// </summary>
        /// <param name="result"></param>
        public void Save(WorkService result)
        {
            _dB.Create(result);
        }
    }
}
