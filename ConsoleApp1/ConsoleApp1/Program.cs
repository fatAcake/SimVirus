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
       private static DateTime now;
        static void Main(string[] args)
        {
            Virus virus = new Tikotoko("Tikotoko-XD", true, 0.3f, 0.05f);

            InputManager();
           
            Simulator sim = new Simulator(_population, _days, virus);
            Observer observer = new Observer(ref sim);
            observer.OnEndSimulation += Results;
            now= DateTime.Now;
            observer.Start();
        }

        private static void InputManager()
        {
            Console.Write("Введите кол-во человек в популяции: ");
            _population = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во дней симуляции: ");
            _days = int.Parse(Console.ReadLine());
            Console.WriteLine("Для досрочного завершения работы программы нажмите Enter");
        }

        private static void Results(Simulator simulator)
        {
            Console.WriteLine("Время симуляции: "+Math.Round((DateTime.Now-now).TotalSeconds),3);
            Console.WriteLine($"Популяция: {simulator.TotalPopulation}");
            Console.WriteLine($"Кол-во смертей: {simulator.DeadPopulation}");
            Console.WriteLine($"Кол-во заражений: {simulator.Illed}");
            Console.WriteLine($"Кол-во выздаровлений: {simulator.Recovered}");
            if (_days + 1 != simulator.Days)
                Console.WriteLine($"Кол-во дней: {simulator.Days}");
        }

    }
}
