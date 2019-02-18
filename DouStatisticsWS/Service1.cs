using System;
using System.ServiceProcess;
using System.Timers;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Providers;
using DouStatisticsWS.Loger;

namespace DouStatisticsWS
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        public static readonly DateTime DateTimeStart = DateTime.Now;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Writer.WriteTextInFile("Start");

            _timer = new Timer(1000 * 60 * 5);
            _timer.AutoReset = true;
            _timer.Elapsed += SendRequest;
            _timer.Start();
        }

        protected override void OnStop()
        {
            //todo: увеличить время до 5 минут
        }

        public void SendRequest(object sender, EventArgs e)
        {
            CompleteRequest();
        }

        /// <summary>
        /// Цыклически выполнять запрос
        /// </summary>
        public void CompleteRequest()
        {
            try
            {
                Writer.WriteTextInFile("Start cycle");

                var dayLastRecord = new SearchResultDTO().GetLastRecordDate().Day;
                var dayNow = DateTime.Now.Day;

                Writer.WriteTextInFile($"последняя запись {dayLastRecord}, текущая дата {dayNow}, длинна масива {TimerRequest.SearchKeywords.Count}");

                if (dayLastRecord == dayNow)
                    return;

                Writer.WriteTextInFile("нет текущей даты");

                if (TimerRequest.SearchKeywords.Count > 0)
                    TimerRequest.SearchKeywords.Clear();

                bool successfulResponse = new TimerRequest(new ProviderDou()).Request();

                if (successfulResponse) //записать успешный результат работы службы
                    new SuccessLogger().SaveResultWorkingService();

                Writer.WriteTextInFile("Stop request");
            }
            catch (Exception e)
            {
                new ErrorLogger().SaveException(e);

                Writer.WriteTextInFile($"Error {e.Message}\n inerMesage {e.InnerException?.Message}\n {e.StackTrace}");
            }
        }
    }
}
