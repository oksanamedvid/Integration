using System;
using System.Linq;
using System.Threading;
using DataRetriverDLL;

namespace DataRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer(TimerCallback, null, 0, 20000);
            Console.ReadLine();
        }

        private static void TimerCallback(object o)
        {
            var dataReader = new WebsiteDataReader();
            var jobs = dataReader.GetDataFromWebsite().ToList();
            jobs.ForEach(DataSender.SendData);
        }

    }
}
