using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp1.Utils;

namespace ConsoleApp1
{
    internal class Observer
    {
        private Simulator _simulator;
        public event Action<Simulator> OnEndSimulation;
        public Observer(ref Simulator simulator) 
        {
            _simulator = simulator; 
        }
        public void Start()
        {
            var SimThread = new Thread(_simulator.RunSimulation);
            SimThread.Start();
            var ExitThread = new Thread(() => EarlyExit(SimThread));
            ExitThread.Start();

            SimThread.Join();
            OnEndSimulation?.Invoke(_simulator);

        }

        private void EarlyExit(Thread simThread)
        {
           while(simThread.IsAlive)
            {
                if(Console.ReadKey().Key==ConsoleKey.Enter&&simThread.IsAlive)
                {
                    simThread.Abort();
                }
            }
        }
    }
}
