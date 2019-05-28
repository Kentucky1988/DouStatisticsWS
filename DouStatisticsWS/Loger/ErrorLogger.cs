using System;
using System.Data.Entity;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;

namespace DouStatisticsWS.Loger
{
    public class ErrorLogger
    {
        private readonly DbContext _dbContext;
        public ErrorLogger(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SaveException(Exception exception, int? keyWordId = null)
        {
            var logException = new LogException
            {
                KeyWordId = keyWordId,
                ExceptionMesage = exception.Message,
                InerExceptionMesage = exception.InnerException?.Message,
                StackTraceException = exception.StackTrace,
                Date = DateTime.Now
            };

            new LogExceptionDTO(_dbContext).SaveError(logException);
        }
    }
}
