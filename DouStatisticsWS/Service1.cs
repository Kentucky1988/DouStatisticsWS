using System;
using System.Data.Entity;
using System.ServiceProcess;
using System.Timers;
using DouStatistics.DAL;
using DouStatistics.Logic.DTO;
using DouStatistics.Logic.Interfaces;
using DouStatistics.Logic.Providers;
using DouStatisticsWS.Loger;

namespace DouStatisticsWS
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        private readonly DateTime _dateTimeStart;
        private DateTime? _daterLastRecord;
        private readonly DbContext _dbContext;
        private readonly IProvider _provider;

        public DateTime DaterLastRecord
        {
            set => _daterLastRecord = value;   
            get => (DateTime)(_daterLastRecord
                ?? (_daterLastRecord = new SearchResultDTO(_dbContext).GetLastRecordDate().Date));
        }

        public Service1()
        {
            _dateTimeStart = DateTime.Now;
            _dbContext = new DouStatisticsDbContext();
            _provider = new ProviderTest();

            InitializeComponent();
        }

        //public void OnStaryDebug()
        //{
        //    OnStart(null);
        //}

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
            //todo: удалить все записи в файл кроме ошибок
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

                Writer.WriteTextInFile($"Последняя запись {DaterLastRecord}, текущая дата {dateNow}, длинна масива {TimerRequest.SearchKeywords.Count}");

                if (dateNow == DaterLastRecord)
                    return;

                Writer.WriteTextInFile("Нет текущей даты");

                if (TimerRequest.SearchKeywords.Count > 0)
                    TimerRequest.SearchKeywords.Clear();

                bool successfulResponse = new TimerRequest(_provider, _dbContext).Request();

                if (successfulResponse)
                { //записать успешный результат работы службы
                    new SuccessLogger(_dbContext).SaveResultWorkingService(_dateTimeStart);
                    DaterLastRecord = new SearchResultDTO(_dbContext).GetLastRecordDate().Date;
                }

                Writer.WriteTextInFile("Stop request");
            }
            catch (Exception e)
            {
                new ErrorLogger(_dbContext).SaveException(e);
                Writer.WriteTextInFile($"Error {e.Message}\n inerMesage {e.InnerException?.Message}\n {e.StackTrace}");
            }
        }
    }
}
