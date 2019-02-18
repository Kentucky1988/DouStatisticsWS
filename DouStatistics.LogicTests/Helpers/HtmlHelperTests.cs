using DouStatistics.Logic.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouStatistics.LogicTests.Helpers
{
    [TestClass()]
    public class HtmlHelperTests
    {
        [TestMethod()]
        public void GetNumberVacanciesTest()
        {
            string html = @"<div class=""sh-info"">Long term international projects for west - europe andUS customers.</div>
                          <div class=""b-inner-page-header"">
                          <h1> 541 вакансия по запросу «.Net»</ h1 >  
                          <a class=""rss"" href=""https://jobs.dou.ua/vacancies/feeds/?search=.Net&amp;descr=1""><em>r</em><span>RSS</span></a>
                          </div>";

            int number = new HtmlHelper().GetNumberVacancies(html);

            Assert.AreEqual(541, number);
        }
    }
}