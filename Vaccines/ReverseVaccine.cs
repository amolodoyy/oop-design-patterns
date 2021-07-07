using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;
        public int Count = 0; // count how many times it was used

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "ReverseVaccine";
        }
        public void VaccinateDog(Dog dog)
        {
            Count++;
            char[] str = Immunity.ToCharArray();
            Array.Reverse(str);
            string reversed = new string(str);
            dog.Immunity = reversed;

        }
        public void VaccinateCat(Cat cat)
        {
            Count++;
            cat.Alive = false;
        }
        public void VaccinatePig(Pig pig)
        {
            Count++;
            char[] str = Immunity.ToCharArray();
            Array.Reverse(str);
            string reversed = new string(str);
            pig.Immunity = Immunity + reversed;
            if (randomElement.NextDouble() < Count * DeathRate)
            {
                pig.Alive = false;
            }
        }
    }
}

