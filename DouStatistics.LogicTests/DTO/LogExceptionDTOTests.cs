﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using DouStatistics.DAL;

namespace DouStatistics.Logic.DTO.Tests
{
    [TestClass()]
    public class LogExceptionDTOTests
    {
        private DbContext _dbContext;
        [ClassInitialize]
        public void TestInitialize()
        {
            _dbContext = new DouStatisticsDbContext();
        }

        [TestMethod()]
        public void SaveErrorTest()
        {
            var logException = new LogExceptionDTO(_dbContext);
            int countExceptionStart = logException.GetAlLogExceptions().Count;
            
            var exception = new LogException
            {
                KeyWordId = 7,
                ExceptionMesage = "Test ExceptionMesage",
                InerExceptionMesage = "Test InerExceptionMesage",
                StackTraceException = @"D:\GitHub\DouStatistics\DouStatisticsWS\DouStatisticsWS\TimerRequest.cs",
                Date = DateTime.Now
            };

            logException.SaveError(exception);

            int countExceptionStop = logException.GetAlLogExceptions().Count;

            Console.WriteLine($"{countExceptionStart} / {countExceptionStop}");
            Assert.AreEqual(countExceptionStart + 1, countExceptionStop);
        }
    }
}