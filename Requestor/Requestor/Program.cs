using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Requestor
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;            
            var tasks = new List<Task>();
            for(int i = 0; i < 100; i++)
            {
                var client = new WebClient();
                tasks.Add(Task.Factory.StartNew(() => client.DownloadData(new Uri("http://localhost/MVCAsync/Home/WidgetsAsync"))));    
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Time elapsed: " + DateTime.Now.Subtract(startTime));
        }
    }
}
