using System;
using System.IO;

namespace DouStatisticsWS
{
    public class Writer
    {
        static object _locker = new object();

        public static void WriteTextInFile(string operation)
        {
            string path = @"C:\Users\Дмитрий\Desktop\timer.txt";

            lock (_locker)
            {
                using (var tw = new StreamWriter(path, File.Exists(path)))
                {
                    tw.WriteLine($"{operation} {DateTime.Now:hh:mm:ss}");
                }
            }
        }
    }
}
