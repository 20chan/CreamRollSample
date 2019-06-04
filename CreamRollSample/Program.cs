using System;
using System.IO;
using System.Threading.Tasks;
using CreamRoll;

using static CreamRoll.RouteServer;

namespace CreamRollSample {
    class Program {
        static void Main(string[] args) {
            var counter = new Counter();
            var server = new RouteServer<Counter>(counter);
            server.StartAsync();

            Console.Write("Press Enter twice to stop..");
            Console.ReadLine();
            Console.ReadLine();
            server.Stop();
            Console.WriteLine("Server stopped");
        }
    }

    public class Counter {
        private int counter = 0;


        [Get("/")]
        public string Count() {
            return (++counter).ToString();
        }

        [Get("/async")]
        public Task<string> AsyncCount() {
            return Task.FromResult((++counter).ToString());
        }
    }
}