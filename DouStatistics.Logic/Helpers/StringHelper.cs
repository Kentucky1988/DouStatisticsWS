using System;
using System.Linq;

namespace DouStatistics.Logic.Helpers
{
    public class StringHelper
    {
        ///<summary>
        /// удалить подстроку между ключевыми словами(подстроками)
        ///</summary>
        public string DeletePartOfString(string text, string startWord, string stopWord)
        {
            int positionStart = text.IndexOf(startWord) + startWord.Length;
            int positionStop = text.IndexOf(stopWord);

            if (positionStart > -1 && positionStop > -1)
                text = text.Remove(positionStart, positionStop - positionStart);

            return text;
        }

        ///<summary>
        /// удалить всю строку кроме подстроки между ключевыми словами(подстроками)
        ///</summary>
        public string LeaveSubstringInString(string text, string startWord, string stopWord)
        {
            int positionStart = text.IndexOf(startWord) + startWord.Length;

            if (positionStart > -1)
                text = text.Remove(0, positionStart);

            int positionStop = text.IndexOf(stopWord);

            if (positionStop > -1)
                text = text.Remove(positionStop, text.Length - positionStop);

            return text;
        }

        ///<summary>
        /// получить количество вакансий 
        ///</summary>
        public int GetNumberVacancies(string html)
        {
            string startWord = "<div class=\"b-inner-page-header\">";
            string stopWord = "вакансия  по запросу";

            html = LeaveSubstringInString(html, startWord, stopWord);

            html = string.Concat(html.Replace("<h1>", "").Where(char.IsDigit));

            if (Int32.TryParse(html, out int number))
                return number;

            return 0;
        }
    }
}