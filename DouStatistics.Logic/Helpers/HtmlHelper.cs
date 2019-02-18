using System;
using System.Linq;
using HtmlAgilityPack;

namespace DouStatistics.Logic.Helpers
{
    public class HtmlHelper
    {
        ///<summary>
        /// получить количество вакансий 
        ///</summary>
        public int GetNumberVacancies(string htmlDocument)
        {
            const string element = "div";
            const string attributes = "class";
            const string name = "b-inner-page-header";

            var resultat = new HtmlDocument();
            resultat.LoadHtml(htmlDocument);

            string innerText = resultat.DocumentNode
                                       .Descendants()
                                       .FirstOrDefault(x => (x.Name == element
                                                          && x.Attributes[attributes] != null 
                                                          && x.Attributes[attributes].Value.Contains(name)))?
                                       .InnerText;

            string value = string.Concat(innerText?.Where(char.IsDigit) ?? "0");

            if (Int32.TryParse(value, out int number))
                return number;

            return 0;
        }
    }
}
