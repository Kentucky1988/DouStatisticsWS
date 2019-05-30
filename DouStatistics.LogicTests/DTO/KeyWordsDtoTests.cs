using System;
using System.Data.Entity;
using System.Linq;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatistics.LogicTests.DTO
{
    [TestClass]
    public class KeyWordsDtoTests
    {
        private DbContext _dbContext;
        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new DouStatisticsDbContext();
        }

        [TestMethod]
        public void GetAllAsyncTest()
        {
            string keyName = ".NET";

            var allKey = new SearchKeywordsDto(_dbContext).GetAll();
            var key = allKey.FirstOrDefault(c => c.KeyWord == keyName);

            Console.WriteLine(key?.KeyWord);
            Assert.IsNotNull(key);
        }
    }
}