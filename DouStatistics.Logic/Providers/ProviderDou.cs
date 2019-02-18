using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Helpers;
using DouStatistics.LogicTests.Interfaces;

namespace DouStatistics.Logic.Providers
{
    public class ProviderDou : IProvider
    {

        /// <summary>
        /// Выполнить Http запрос
        /// </summary>
        /// <param name="url">адрес по которому необходимо выполнить запрос</param>
        /// <returns></returns>
        public async Task<string> HttpRequest(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            using (var client = new HttpClient())
            {
                var urlRequest = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(urlRequest);

                if (response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();

                throw new Exception($"Ошибка запроса DOU {urlRequest} StatusCode:{response.StatusCode} mesage:{response.ReasonPhrase}");
            }
        }

        ///<summary>
        /// Получить количество вакансий
        ///</summary>
        public ResultsSearch NumberOfVacancies(KeyWords keyWord)
        {
            bool isCategory = keyWord.IsCategory ?? false;
            string urlDou = UrlHelper.GetStringUrl(keyWord.KeyWord, isCategory);

            string resultRequest = HttpRequest(urlDou).Result;
            int amount = new HtmlHelper().GetNumberVacancies(resultRequest);

            var result = new ResultsSearch
            {
                KeyWordId = keyWord.Id,
                Amount = amount,
                Date = DateTime.Now
            };

            return result;
        }
    }
}