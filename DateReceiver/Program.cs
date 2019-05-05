using DataReceiver;
using DataReceiver.Services;

namespace DateReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new JobContext())
            {
                context.JobVacancies.RemoveRange();
                context.SaveChanges();
            }

            var listener = new DataListenerService();
            listener.Register();
        }
    }
}
