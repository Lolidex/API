using System;
using System.Threading;
using Nancy;
using Nancy.Hosting.Self;

namespace API
{
    class Program
    {

        private static NancyHost _host;

        static void Main(string[] args)
        {
            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                RewriteLocalhost = false 
            };

            _host = new NancyHost(hostConfiguration, new Uri("http://localhost:8888"));

            _host.Start();

            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("^c pressed quiting..");

                _host.Stop();
            };

            while (true) Thread.Sleep(1);
        }

    }
}
