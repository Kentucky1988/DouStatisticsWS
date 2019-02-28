using System;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;

namespace DouStatisticsWS.Loger
{
    class SuccessLogger
    {
        /// <summary>
        /// Записать результат работы службы, после успешной обработки всех запросов
        /// </summary>
        public void SaveResultWorkingService(DateTime dateTimeStart)
        {
            var timeWork = TimeSpan.FromMilliseconds(TimerRequest.TimeExecutionRequests.ElapsedMilliseconds)
                                   .TotalSeconds;

            var workingService = new WorkService
            {
                StartTime = dateTimeStart,
                StopTime = DateTime.Now,
                NumberRequests = TimerRequest.Index,
                TimeExecutionRequests = (int)timeWork
            };

            new WorkingServiceDTO().Save(workingService);
        }
    }
}
