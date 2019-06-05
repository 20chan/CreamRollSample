using System;
using System.Collections.Generic;
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
        private Dictionary<string, int> countDict = new Dictionary<string, int>();

        [Get("/{name}/cnt")]
        public string Count(RouteServerBase.RouteContext ctx) {
            countDict.TryAdd(ctx.Query.name, 0);
            return (++countDict[ctx.Query.name]).ToString();
        }
    }
}