using System;
using System.Threading;
using Nancy.Hosting.Self;
using RethinkDb.Driver;
using RethinkDb.Driver.Net;

namespace API
{
    class Program
    {
        public static Connection Conn;

        private static RethinkDB R = RethinkDB.R;
        private static NancyHost _host;

        static void Main(string[] args)
        {
            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                RewriteLocalhost = false 
            };

            // run behind nginx proxy
            _host = new NancyHost(hostConfiguration, new Uri("http://localhost:8888"));

            try
            {
                Conn = R.Connection()
                     .Hostname("localhost")
                     .Port(RethinkDBConstants.DefaultPort)
                     .Timeout(RethinkDBConstants.DefaultTimeout)
                     .Connect();
            }catch(Exception e)
            {
                Console.WriteLine("Can't connect to RethinkDB database: " + e.Message);

                return;
            }

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
