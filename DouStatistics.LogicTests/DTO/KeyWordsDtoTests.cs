using System;
using System.Linq;
using DouStatistics.Logic.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatistics.LogicTests.DTO
{
    [TestClass()]
    public class KeyWordsDtoTests
    {
        [TestMethod()]
        public void GetAllAsyncTest()
        {
            string keyName = ".NET";

            var allKey = new SearchKeywordsDto().GetAll();
            var key = allKey.FirstOrDefault(c => c.KeyWord == keyName);

            Console.WriteLine(key?.KeyWord);
            Assert.IsNotNull(key);
        }
    }
}