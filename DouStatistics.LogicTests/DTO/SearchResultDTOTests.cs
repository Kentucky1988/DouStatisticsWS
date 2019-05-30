using DouStatistics.Logic.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DouStatistics.DAL.Interfaces;
using Moq;
using DouStatistics.DAL;
using System.Data.Entity;
using DouStatistics.LogicTests.DTO.StubObject;

namespace DouStatistics.Logic.DTO.Tests
{
    [TestClass()]
    public class SearchResultDTOTests
    {
        SearchResultDTO _searchResultDTO;
        Mock<IRepository<ResultsSearch>> _mockRepository;

        private DbContext _dbContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new DouStatisticsDbContext();

            _mockRepository = new Mock<IRepository<ResultsSearch>>();
            _searchResultDTO = new SearchResultDTO(_mockRepository.Object);

        }

        [TestMethod()]
        public void SaveResultTest()
        {
            _mockRepository.Setup(c => c.Create(It.IsAny<ResultsSearch>()));
            _searchResultDTO.SaveResult(new ResultsSearch());

            _mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            _mockRepository.Setup(c => c.GetAll());
            _searchResultDTO.GetAll();

            _mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void GetLastRecordDateTest()
        {
            var stubRepository = new ResultsSearchStubRepository<ResultsSearch>();
            _searchResultDTO = new SearchResultDTO(stubRepository);

            DateTime date = new DateTime(2019, 01, 03, 00, 01, 00);

            var dateLastRecord = _searchResultDTO.GetLastRecordDate();

            Assert.AreEqual(date, dateLastRecord);
        }

        [TestMethod()]
        public void GetLastRecordDateTest1()
        {
            var stubRepository = new ResultsSearchStubRepository<ResultsSearch>();
            _searchResultDTO = new SearchResultDTO(stubRepository);

            DateTime date = new DateTime(2019, 01, 02, 00, 01, 00);

            var dateLastRecord = _searchResultDTO.GetLastRecordDate();

            Assert.AreNotEqual(date, dateLastRecord);
        }

        [TestMethod()]
        public void GetLastRecordDateTest2()
        {
            _mockRepository.Setup(c => c.GetAll());
            _searchResultDTO.GetAll();

            _mockRepository.VerifyAll();
        }
    }
}