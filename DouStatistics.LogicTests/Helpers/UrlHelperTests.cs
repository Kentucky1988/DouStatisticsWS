using System;
using DouStatistics.Logic.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatistics.Logic.Helpers.Tests
{
    [TestClass()]
    public class UrlHelperTests
    {
        [TestMethod()]
        public void GetStringUrlTest()
        {
            string url = "https://jobs.dou.ua/vacancies/?category=.Net";

            string keyWord = ".Net";
            string result = UrlHelper.GetStringUrl(keyWord, true);
            Console.WriteLine(result);

            Assert.AreEqual(url, result);
        }

        [TestMethod()]
        public void GetStringUrlTest1()
        {
            string url = "https://jobs.dou.ua/vacancies/?category=C%2B%2B";

            string keyWord = "C++";
            string result = UrlHelper.GetStringUrl(keyWord, true);
            Console.WriteLine(result);

            Assert.AreEqual(url, result);
        }
    }
}

namespace DouStatistics.LogicTests.Helpers
{
    [TestClass()]
    public class UrlHelperTests
    {
        [TestMethod()]
        public void GetStringUrlTest()
        {
            string url = "https://jobs.dou.ua/vacancies/?search=.Net&descr=1";

            string keyWord = ".Net";
            string result = UrlHelper.GetStringUrl(keyWord);

            Assert.AreEqual(url, result);
        }

        [TestMethod()]
        public void GetStringUrlTest2()
        {
            string url = "https://jobs.dou.ua/vacancies/?search=C%23&descr=1";

            string keyWord = "C#";
            string result = UrlHelper.GetStringUrl(keyWord);

            Assert.AreEqual(url, result);
        }

        [TestMethod()]
        public void GetStringUrlTest3()
        {
            string url = "https://jobs.dou.ua/vacancies/?search=C%2B%2B&descr=1";

            string keyWord = "C++";
            string result = UrlHelper.GetStringUrl(keyWord);

            Assert.AreEqual(url, result);
        }

        [TestMethod()]
        public void GetStringUrlTest4()
        {
            string url = "https://jobs.dou.ua/vacancies/?search=UX%2FUI&descr=1";

            string keyWord = "UX/UI";
            string result = UrlHelper.GetStringUrl(keyWord);

            Assert.AreEqual(url, result);
        }

        [TestMethod()]
        public void GetStringUrlTest5()
        {
            string url = "https://jobs.dou.ua/vacancies/?search=junior+PHP&descr=1";

            string keyWord = "junior PHP";
            string result = UrlHelper.GetStringUrl(keyWord);

            Assert.AreEqual(url, result);
        }
    }
}