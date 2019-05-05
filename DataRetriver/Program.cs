using System;
using System.Linq;
using DataRetriverDLL;

namespace DataRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataReader = new WebsiteDataReader();
            var jobs = dataReader.GetDataFromWebsite().ToList();

            jobs.ForEach(DataSender.SendData);

            Console.ReadLine();
        }

    }
}
