using System.Collections.Generic;
using System.Data.Entity;
using DouStatistics.DAL;
using DouStatistics.DAL.Interfaces;
using DouStatistics.DAL.Repository;

namespace DouStatistics.Logic.DTO
{
    public class LogExceptionDTO
    {
        private readonly IRepository<LogException> _dB;

        public LogExceptionDTO(DbContext dbContext)
        {
            _dB = new GenericRepository<LogException>(dbContext);
        }

        public LogExceptionDTO(IRepository<LogException> dB)
        {
            _dB = dB;
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
