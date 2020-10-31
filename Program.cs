using System;
using System.Net;

namespace smart_hub_console_controller
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No url found");
                Environment.Exit(0);
                return;
            }
            var url = args[0];
            if (url != null)
            {
                Console.WriteLine(url);
                try
                {
                    var json = new TimedWebClient().DownloadString(url);
                    Console.WriteLine("OK");
                }
                catch
                {
                    Console.WriteLine("TIMEOUT");
                }
            }
            Environment.Exit(0);
        }
    }

    public class TimedWebClient : WebClient
    {
        // Timeout in milliseconds, default = 600,000 msec
        public int Timeout { get; set; }

        public TimedWebClient()
        {
            this.Timeout = 10000;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = this.Timeout;
            return objWebRequest;
        }
    }
}
