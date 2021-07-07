using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }
        public void VaccinateDog(Dog dog)
        {
            dog.Immunity = Immunity;
        }
        public void VaccinateCat(Cat cat)
        {

            cat.Immunity = Immunity.Substring(3);
            if (randomElement.NextDouble() < DeathRate) 
            {
                cat.Alive = false;
            }
        }
        public void VaccinatePig(Pig pig)
        {
            pig.Alive = false;
        }
    }
}
