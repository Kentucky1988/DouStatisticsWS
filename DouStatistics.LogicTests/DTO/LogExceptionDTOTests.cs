using Microsoft.VisualStudio.TestTools.UnitTesting;
using DouStatistics.DAL;
using DouStatistics.DAL.Interfaces;
using Moq;

namespace DouStatistics.Logic.DTO.Tests
{
    [TestClass()]
    public class LogExceptionDTOTests
    {
        LogExceptionDTO _logException;
        Mock<IRepository<LogException>> _mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IRepository<LogException>>();
            _logException = new LogExceptionDTO(_mockRepository.Object);
        }

        //[TestMethod()]
        //public void SaveErrorTest()
        //{
        //    var logException = new LogExceptionDTO(_dbContext);
        //    int countExceptionStart = logException.GetAlLogExceptions().Count;

        //    var exception = new LogException
        //    {
        //        KeyWordId = 7,
        //        ExceptionMesage = "Test ExceptionMesage",
        //        InerExceptionMesage = "Test InerExceptionMesage",
        //        StackTraceException = @"D:\GitHub\DouStatistics\DouStatisticsWS\DouStatisticsWS\TimerRequest.cs",
        //        Date = DateTime.Now
        //    };

        //    logException.SaveError(exception);

        //    int countExceptionStop = logException.GetAlLogExceptions().Count;

        //    Console.WriteLine($"{countExceptionStart} / {countExceptionStop}");
        //    Assert.AreEqual(countExceptionStart + 1, countExceptionStop);
        //}

        [TestMethod]
        public void GetAlLogExceptionsTest()
        {
            _mockRepository.Setup(c => c.GetAll());
            _logException.GetAlLogExceptions();

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void SaveErrorTest()
        {
            _mockRepository.Setup(c => c.Create(It.IsAny<LogException>()));
            _logException.SaveError(new LogException());

            _mockRepository.VerifyAll();
        }
    }
}