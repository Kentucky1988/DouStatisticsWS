using System;
using System.Data.Entity;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatistics.LogicTests.DTO
{
    [TestClass()]
    public class ResultsSearchDtoTests
    {
        private DbContext _dbContext;
        [ClassInitialize]
        public void TestInitialize()
        {
            _dbContext = new DouStatisticsDbContext();
        }

        [TestMethod()]
        public void GetLastRecordDateTest()
        {
            var resultSearch = new SearchResultDTO(_dbContext);
            var dateLastRecord = resultSearch.GetLastRecordDate();

            Console.WriteLine(dateLastRecord +" / "+ dateLastRecord.Day);
        }

        [TestMethod()]
        public void SaveResult_AsyncTest()
        {
            var searchResult = new SearchResultDTO(_dbContext);
            var countStart = searchResult.GetAll().Count;
            var model = new ResultsSearch
            {
                KeyWordId = 8,
                Amount = 100,
                Date = DateTime.Now
            };

            searchResult.SaveResult(model);
            var countStop = searchResult.GetAll().Count;

            Console.WriteLine($"{countStart} / {countStop}");
            Assert.AreEqual(countStart + 1, countStop);
        }
    }
}
