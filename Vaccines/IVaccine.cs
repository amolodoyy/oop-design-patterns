using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    interface IVaccine
    {
        public string Immunity { get; }
        public double DeathRate { get; }

        // Visit() analogues
        public void VaccinateCat(Cat cat);
        public void VaccinateDog(Dog dog);
        public void VaccinatePig(Pig pig);
    }
}
