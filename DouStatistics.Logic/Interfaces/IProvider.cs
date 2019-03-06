using DouStatistics.DAL;

namespace DouStatistics.Logic.Interfaces
{
    public interface IProvider
    {
        ResultsSearch NumberOfVacancies(KeyWords keyWord);
    }
}
