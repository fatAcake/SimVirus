using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    internal class Program
    {
        private static int _population;
        private static int _days;
        static void Main(string[] args)
        {



            
            
           


        }
        
        private static void Results(Simulator simulator)
        {
            Console.WriteLine($"{simulator.TotalPopulation}");

            Console.WriteLine($"{simulator.DeadPopulation}");
            Console.WriteLine($"{simulator.FallIll}");
            Console.WriteLine($"{simulator.Recovered}");
            if(_days!=simulator.Days)
            {
                Console.WriteLine($"{_days}");
            }

        }

    }
}
