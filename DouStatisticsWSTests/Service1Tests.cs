using System;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Providers;
using DouStatisticsWS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatisticsWSTests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void CompleteRequestTest()
        {
            var searchKeywords = new SearchKeywordsDto().GetAll();

            new Service1().CompleteRequest();

            var result = new SearchResultDTO().GetAll();

            Console.WriteLine($"keywords {searchKeywords.Count} / result {result.Count}");
            Assert.AreEqual(searchKeywords.Count, result.Count);
        }
    }
}