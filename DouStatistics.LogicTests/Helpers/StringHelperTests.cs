using System;
using DouStatistics.Logic.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatistics.LogicTests.Helpers
{
    [TestClass()]
    public class StringHelperTests
    {
        [TestMethod()]
        public void GetNumberOfRepetitionsTest()
        {
            int number = 541;
            string html = @"<div class=""b-inner-page-header"">
                          <h1>541 вакансия  по запросу «.Net»</h1>        
                          <a class=""rss"" href=""https://jobs.dou.ua/vacancies/feeds/?search=.Net&amp;descr=1""><em>r</em><span>RSS</span></a>
                          </div>";

            int res = new StringHelper().GetNumberVacancies(html);
            Console.WriteLine(res);

            Assert.AreEqual(number, res);
        }

        [TestMethod()]
        public void LeaveSubstringInStringTest()
        {
            string start = @"class=""b-inner-page-header"">";
            string stop = @"</div>";
            string strResult = @"<h1>541 вакансия  по запросу «.Net»</h1>";
            string html = @"<div class=""b-inner-page-header""><h1>541 вакансия  по запросу «.Net»</h1></div>";

            string result = new StringHelper().LeaveSubstringInString(html, start, stop);
            Console.WriteLine(result);

            Assert.AreEqual(strResult, result);
        }

        [TestMethod()]
        public void DeletePartOfStringTest()
        {
            string start = @"class=""b-inner-page-header"">";
            string stop = @"</div>";
            string strResult = @"<div class=""b-inner-page-header""></div>";
            string html = @"<div class=""b-inner-page-header""><h1>541 вакансия  по запросу «.Net»</h1></div>";

            string result = new StringHelper().DeletePartOfString(html, start, stop);
            Console.WriteLine(result);

            Assert.AreEqual(strResult, result);
        }
    }
}