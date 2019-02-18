using System;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;

namespace DouStatisticsWS.Loger
{
    public class ErrorLogger
    {
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

            new LogExceptionDTO().SaveError(logException);
        }
    }
}
