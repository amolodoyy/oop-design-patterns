using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }
        public void VaccinateDog(Dog dog)
        {
            string imun = new string(Enumerable.Repeat(Immunity, 3000).Select(s => s[randomElement.Next(s.Length)]).ToArray());
            dog.Immunity = imun;
            if(randomElement.NextDouble() < DeathRate)
                dog.Alive = false;
        }
        public void VaccinateCat(Cat cat)
        {
            string imun = new string(Enumerable.Repeat(Immunity, 300).Select(s => s[randomElement.Next(s.Length)]).ToArray());
            cat.Immunity = imun;
            if (randomElement.NextDouble() < DeathRate)
                cat.Alive = false;
        }
        public void VaccinatePig(Pig pig)
        {
            string imun = new string(Enumerable.Repeat(Immunity, 15).Select(s => s[randomElement.Next(s.Length)]).ToArray());
            pig.Immunity = imun;
            if (randomElement.NextDouble() < 3* DeathRate)
                pig.Alive = false;
        }
    }
}

