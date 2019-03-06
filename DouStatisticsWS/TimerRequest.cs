using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Interfaces;
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
        }

        public bool Request()
        {
            try
            {
                var searchKeywords = new SearchKeywordsDto().GetAll();
                SearchKeywords.AddRange(searchKeywords);

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
                            ErrorLogger.SaveException(e, keyword.Id);

                            Writer.WriteTextInFile($"Error {e.Message}\n inerMesage {e.InnerException?.Message}\n {e.StackTrace}");
                            Thread.Sleep(TimeSpan.FromMinutes(1));
                        }
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                ErrorLogger.SaveException(exception);
                Writer.WriteTextInFile($"{exception.Message}\n {exception.InnerException}\n {exception.StackTrace}");
            }

            TimeExecutionRequests.Stop();
            return false;
        }
    }
}
