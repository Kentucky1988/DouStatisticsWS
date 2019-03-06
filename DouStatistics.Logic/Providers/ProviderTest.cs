using System;
using DouStatistics.DAL;
using DouStatistics.Logic.Interfaces;

namespace DouStatistics.Logic.Providers
{
    /// <summary>
    /// Тестовый провайдер.
    /// </summary>
    public class ProviderTest : IProvider
    {
        private int _key = 0;

        /// <summary>
        ///  Симулирует ответ провайдера. Генерит ошибку на каждом 40 запросе
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public ResultsSearch NumberOfVacancies(KeyWords keyWord)
        {
            _key++;

            if (_key % 40 == 0) //имитация ошибки подключения
                throw new Exception("Ошибка подключения");

            var reqModel = new ResultsSearch
            {
                Amount = _key,
                Date = DateTime.Now,
                Id = keyWord.Id
            };

            return reqModel;
        }
    }
}
