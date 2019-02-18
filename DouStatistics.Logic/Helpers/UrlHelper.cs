namespace DouStatistics.Logic.Helpers
{
    public class UrlHelper
    {
        ///<summary>
        /// Создать Url запроса
        ///</summary>
        public static string GetStringUrl(string keyWord, bool isCategory = false)
        {
            keyWord = keyWord.Replace(" ", "+")
                             .Replace("#", "%23")
                             .Replace("/", "%2F")
                             .Replace("++", "%2B%2B");

            string urlDou = "https://jobs.dou.ua/vacancies";

            if (isCategory)
                urlDou = $"{urlDou}/?category={keyWord}";
            else
                urlDou = $"{urlDou}/?search={keyWord}&descr=1";

            return urlDou;
        }
    }
}