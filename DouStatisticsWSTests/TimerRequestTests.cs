using System;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Providers;
using DouStatisticsWS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatisticsWSTests
{
    [TestClass()]
    public class TimerRequestTests
    {
        [TestMethod()]
        public void RequestTest()
        {
            var searchKeywords = new SearchKeywordsDto().GetAll();
            new TimerRequest(new ProviderDou()).Request();

            var result = new SearchResultDTO().GetAll();

            Console.WriteLine($"keywords {searchKeywords.Count} / result {result.Count}");
            Assert.AreEqual(searchKeywords.Count, result.Count);
        }

        [TestMethod()]
        public void RequestTest1()
        {
            new TimerRequest(new ProviderTest()).Request();
        }
    }
}