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
        private readonly DateTime _dateTimeStart;
        private DateTime _daterLastRecord;

        public Service1()
        {
            _daterLastRecord = new SearchResultDTO().GetLastRecordDate().Date;
            _dateTimeStart = DateTime.Now;
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
            //todo: удалить все запихи в файл кроме ошибок
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
                var dateNow = DateTime.Now.Date;

                Writer.WriteTextInFile($"Последняя запись {_daterLastRecord}, текущая дата {dateNow}, длинна масива {TimerRequest.SearchKeywords.Count}");

                if (dateNow == _daterLastRecord)
                    return;

                Writer.WriteTextInFile("нет текущей даты");

                if (TimerRequest.SearchKeywords.Count > 0)
                    TimerRequest.SearchKeywords.Clear();

                bool successfulResponse = new TimerRequest(new ProviderDou()).Request();

                if (successfulResponse)
                { //записать успешный результат работы службы
                    SuccessLogger.SaveResultWorkingService(_dateTimeStart);
                    _daterLastRecord = new SearchResultDTO().GetLastRecordDate().Date;
                }

                Writer.WriteTextInFile("Stop request");
            }
            catch (Exception e)
            {
                ErrorLogger.SaveException(e);
                Writer.WriteTextInFile($"Error {e.Message}\n inerMesage {e.InnerException?.Message}\n {e.StackTrace}");
            }
        }
    }
}
