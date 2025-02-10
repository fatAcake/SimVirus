using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utils
{
    class Simulator
    {
        private const double _mortality = (double)14 / 1000;
        private const double _birthrate = (double)8 / 1000;

        private static Random _random = new Random();
        private List<Person> _alive;
        private List<Person> _dead;
        private int _maxDays;
        private int _day;
        private Virus _virus;

        public int Days => _day;
        public Simulator(int countPopulation, int maxDays, Virus virus)
        {
            _day = 1;
            _maxDays = maxDays;
            _alive = new List<Person>();
            _dead = new List<Person>();
            _virus = virus;
            Population(countPopulation);
        }
        public void RunSimmulation()
        {
            StartInfection();
            for (int i = 0; i < _maxDays; i++)
            {
                _day = i;
                if (i % 365 == 0)
                {

                }
                _alive.RemoveAll((p) =>
                {
                    p.UpdateAge();
                    if (p.Age >= p.MaxAge)
                    {
                        _dead.Add(p);
                        return true;
                    }
                    return false;
                });
                StartInfection();
                Mortaliti();
                Birth();
            }
        }
        public int InfectedPopulation() => _alive.FindAll((p) => p.Status).Count;

        //private void UpdatePopulation(int Start, int Count)
        //{
        //    List<Person> list = _alive.GetRange(Start, Count);
        //    foreach (Person person in list)
        //    {
        //        _dead.Add(person);
        //        _alive.Remove(person);
        //    }
        //}
        private void Mortaliti()
        {
            int range = (int)Math.Round(_alive.Count * _mortality / 365);
            List<Person> a = _alive.GetRange(0, range);
            _alive.RemoveRange(0, (int)Math.Round(_alive.Count * _mortality));
            for (int i = 0; i < a.Count; i++)
            {
                _dead.Add(a[i]);
            }
        }
        private void Birth()
        {
            int range = (int)Math.Round(_alive.Count * _mortality / 365);
            for (int i = 0; i < range; i++)
            {
                Person person = new Person(
                    _random.Next(0, 2) == 0 ? "Male" : "Famale", 0,
                    _random.Next(65, 76) / 100);
                _alive.Add(person);
            }
        }
        private void StartInfection()
        {
            for (int i = 0; i < Math.Round(_alive.Count * 0.02); i++)
            {
                _alive.Find((p) => (p.Age >= _virus.AgeToInfect) && (!p.Status)).Status = true;
            }
            _alive = _alive.OrderBy(_ => _random.Next()).ToList();
        }
        private void Infection()
        {
            var allInfected = _alive.FindAll((p) => p.Status);
            
            foreach (var p in allInfected)
            {
                if (p.UpdateInfection() != 0)
                {
                   
                    if (28 > _random.Next(0, 100))
                    {

                        for (int i = 0; i < p.Friends /2; i++)
                        {
                            Person meeting = _alive[_random.Next(0, _alive.Count)];
                            if (_virus.Reinfection && !meeting.TotalImmunity)
                            {
                                if (!meeting.Status)
                                {
                                    _virus.Infect(meeting);
                                }
                            }

                            
                            
                        }
                    }
                    else
                    {
                        if(!_virus.Reinfection)
                        {
                            p.CreateTotalImmunity();
                        }
                    }
                }

            }
        }
        private void Population(int countPopulation)
        {
            string[] gender = new string[2] { "Male", "Famale" };
            int maxAge = 29201;
            double maxImmunity = 0.75;

            for (int i = 0; i < countPopulation; i++)
            {
                Person person = new Person(
                    gender[_random.Next(0, 2)],
                    _random.Next(0, 81),
                    _random.Next(65, 76) / 100);
                if (person.Age >= person.MaxAge)
                    _dead.Add(person);
                else
                    _alive.Add(person);
            }

        }
    }
}
