﻿using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        private const float _coefLostImmunity = 0.000017f;
        private string _gender;
        private int _age;
        private float _initialImmunity;
        private float _immunity;
        private bool _totalImmunity;
        private bool _isAlive;
        private int _friends;
        private int _infectionDayes;
        private bool _status;

        public int Age => _age;
        public int MaxAge => 80;
        public string Gender => _gender;
        public float Immunity => _immunity;
        public bool TotalImmunity => _totalImmunity;
        public bool IsAlive => _isAlive;
        public bool Status =>_status;
        public int Friends => _friends;
        public Person(string Gender, int Age, float Immunity)
        {
            _gender = Gender;
            _age = Age;
            _initialImmunity = Immunity;
            _totalImmunity = false;
            _isAlive = true;
            _friends = (int)Gousian.RandNormal(3, 1);
            _status = false;
            _infectionDayes = 0;
            UpdateImmunity();
        }
        public int UpdateInfection()
        {
            if (!Status) return _infectionDayes=0;
           return _infectionDayes++;


        }
        public void UpdateAge()
        {
            _age++;
            if (_age >= MaxAge)
            {
                Detach();
            }
            UpdateImmunity();
        }
        public void Detach() => _isAlive = false;
        public void Infect()=>_status = true;
        public void Recover()=>_status = false;
        public void CreateTotalImmunity() => _totalImmunity = true;
        private void UpdateImmunity()
        {
            if (!IsAlive)
                return;
            _immunity = _initialImmunity - _coefLostImmunity * Age * 365;
        }
    }
}
