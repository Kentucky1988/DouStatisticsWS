using System;
using System.Data.Entity;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Interfaces;
using DouStatistics.Logic.Providers;
using DouStatisticsWS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatisticsWSTests
{
    [TestClass()]
    public class TimerRequestTests
    {
        private DbContext _dbContext;
        private IProvider _provider;

        [ClassInitialize]
        public void TestInitialize()
        {
            _provider = new ProviderTest();
            _dbContext = new DouStatisticsDbContext();
        }

        [TestMethod()]
        public void RequestTest()
        {
            var searchKeywords = new SearchKeywordsDto(_dbContext).GetAll();
            new TimerRequest(_provider, _dbContext).Request();

            var result = new SearchResultDTO(_dbContext).GetAll();

            Console.WriteLine($"keywords {searchKeywords.Count} / result {result.Count}");
            Assert.AreEqual(searchKeywords.Count, result.Count);
        }

        [TestMethod()]
        public void RequestTest1()
        {
            new TimerRequest(_provider, _dbContext).Request();
        }
    }
}