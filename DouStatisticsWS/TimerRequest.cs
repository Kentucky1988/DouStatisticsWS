using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using DouStatistics.LogicTests.Interfaces;
using DouStatisticsWS.Loger;

namespace DouStatisticsWS
{
    public class TimerRequest
    {
        private readonly IProvider _provider;
        public static int Index;
        public static Stopwatch TimeExecutionRequests;
        public static List<KeyWords> SearchKeywords = new List<KeyWords>();

        public TimerRequest(IProvider provider)
        {
            Index = 0;
            _provider = provider;
            TimeExecutionRequests = new Stopwatch();
            SearchKeywords = new SearchKeywordsDto().GetAll();
        }

        public bool Request()
        {
            try
            {
                var saveResuly = new SearchResultDTO();


                foreach (var keyword in SearchKeywords.ToList())
                {
                    Index++;

                    while (SearchKeywords.Contains(keyword))
                    {
                        try
                        {
                            TimeExecutionRequests.Start();

                            var result = _provider.NumberOfVacancies(keyword);
                            saveResuly.SaveResult(result);
                            SearchKeywords.Remove(keyword); //удаление из списка елемента по которому был успешный ответ и он записан в базу

                            TimeExecutionRequests.Stop();
                        }
                        catch (Exception e)
                        {
                            new ErrorLogger().SaveException(e, keyword.Id);

                            Writer.WriteTextInFile($"Error {e.Message}\n inerMesage {e.InnerException?.Message}\n {e.StackTrace}");
                            Thread.Sleep(TimeSpan.FromMinutes(1));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                new ErrorLogger().SaveException(exception);
                Writer.WriteTextInFile($"{exception.Message}\n {exception.InnerException}\n {exception.StackTrace}");
            }

            TimeExecutionRequests.Stop();

            return true;
        }
    }
}
