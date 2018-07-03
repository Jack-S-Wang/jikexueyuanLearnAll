using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace owin.host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<DiagnosticsStartup>("http://localhost:10002"))
            {
                System.Console.WriteLine("启动控制点……");
                Console.ReadLine();
            }
        }
    }
}
