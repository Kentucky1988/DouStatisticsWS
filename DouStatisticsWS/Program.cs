using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DouStatisticsWS
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {

//#if DEBUG
//            Service1 service1 = new Service1();
//            service1.OnStaryDebug();
//#else

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
//#endif
        }
    }
}
