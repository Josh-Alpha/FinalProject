using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Country
    {
        public string Name { get; set; }
        public string Vote { get; set; }
        public string Number { get; set; }
        public double pop { get; set; }

        public Country(string n, int N,double Pop)
        {
            Name = n;
            Vote = "Yes";
            Number = N.ToString();
            pop = Pop;
        }
    }
}
