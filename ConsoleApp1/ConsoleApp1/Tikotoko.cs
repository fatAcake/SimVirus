using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Tikotoko : Virus
    {
        private static Random _rand = new Random();

        public Tikotoko(string Code, bool Reinfection, float InfectionCoef, float LethalityCoef) : base(Code, Reinfection, InfectionCoef, LethalityCoef)
        {
            _letality = LethalityCoef;
        }
        public override int AgeToInfect => 5;

        public override int DayToRecover => 120;

        public override bool Death(Person person)
        {
            if (_rand.NextDouble() <= Lethality)
            {
                person.Detach();
                return true;
            }
            return false;
        }

        public override void Infect(Person person)
        {
            if (person.Immunity <= Infection)
                person.Infect();
        }







    }
}
