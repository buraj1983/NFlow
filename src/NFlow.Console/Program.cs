using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFlow.Core;

namespace NFlow.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new Process<ProcessResult>();

            System.Console.WriteLine($"System threads {Process.GetCurrentProcess().Threads.Count}.");
            System.Console.ReadLine();

            var task = process.RunAsync();

            System.Console.WriteLine($"System threads {Process.GetCurrentProcess().Threads.Count}.");
            while (true)
            {
                System.Console.WriteLine($"System threads {Process.GetCurrentProcess().Threads.Count}.");

                var ssss = System.Console.ReadLine();

                if (ssss == "exit")
                    break;
            }

            
            

            var ss = task.Result;
               

            System.Console.ReadLine();
        }
        
    }
}
