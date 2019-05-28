using System;
using System.Data.Entity;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Providers;
using DouStatisticsWS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatisticsWS.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void Service1Test()
        {
            var s = new Service1();
            Assert.Fail();
        }
    }
}

namespace DouStatisticsWSTests
{
    [TestClass()]
    public class Service1Tests
    {
        private DbContext _dbContext;
        [ClassInitialize]
        public void TestInitialize()
        {
            _dbContext = new DouStatisticsDbContext();
        }
        [TestMethod()]
        public void CompleteRequestTest()
        {
            var searchKeywords = new SearchKeywordsDto(_dbContext).GetAll();

            new Service1().CompleteRequest();

            var result = new SearchResultDTO(_dbContext).GetAll();

            Console.WriteLine($"keywords {searchKeywords.Count} / result {result.Count}");
            Assert.AreEqual(searchKeywords.Count, result.Count);
        }
    }
}