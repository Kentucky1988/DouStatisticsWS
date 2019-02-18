using System.Threading.Tasks;
using DouStatistics.DAL;

namespace DouStatistics.LogicTests.Interfaces
{
    public interface IProvider
    {
        ResultsSearch NumberOfVacancies(KeyWords keyWord);
    }
}
