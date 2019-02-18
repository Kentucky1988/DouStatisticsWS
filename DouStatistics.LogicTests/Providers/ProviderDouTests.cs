using System;
using System.Collections.Generic;
using DouStatistics.DAL;
using DouStatistics.Logic.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatistics.LogicTests.Providers
{
    [TestClass()]
    public class ProviderDouTests
    {
        [TestMethod()]
        public void HttpRequestTest()
        {
            string url = "https://jobs.dou.ua/vacancies/?search=.Net&descr=1";

            string result = new ProviderDou().HttpRequest(url).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void NumberOfRepetitionsTest()
        {
            var listKeywords = new List<KeyWords>
            {
                new KeyWords {Id = 8, KeyWord = ".Net"},
                new KeyWords {Id = 17, KeyWord = "JavaScript"},
                new KeyWords {Id = 21, KeyWord = "Python"}
            };

            foreach (var keyword in listKeywords)
            {
                var result = new ProviderDou().NumberOfVacancies(keyword);
                Console.WriteLine($"{keyword.KeyWord} - {result.Amount}");

                Assert.AreNotEqual(0, result.Amount);
            }
        }
    }
}