using System.Collections.Generic;
using DouStatistics.DAL;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class LogExceptionDTO
    {
        private readonly GenericRepository<LogException> _dB;

        public LogExceptionDTO()
        {
            _dB = new GenericRepository<LogException>();
        }

        public List<LogException> GetAlLogExceptions()
        {
            return _dB.GetAll();
        }

        public void SaveError(LogException exception)
        {
            _dB.Create(exception);
        }
    }
}
