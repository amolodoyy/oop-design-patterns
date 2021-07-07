using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;
using Task3.Iterators;
using Task3.Databases;
using Task3.Decorators;
namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(IDatabaseIterator iter)
            {
                while(iter.MoveNext())
                {
                    if(iter.Current != null)
                        Console.WriteLine(iter.Current);
                }
            }
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"Testing {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        // process of vaccination
                        subject.Vaccinate(vaccine);
                        if (!subject.Alive)
                            Console.WriteLine($"Vaccine killed the subject. {subject.GetType().Name}, ID:{subject.ID} is dead!");
                        else
                            Console.WriteLine($"Subject is alive. Vaccine did not kill {subject.GetType().Name}, ID:{subject.ID}!");
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function
                    Console.WriteLine("Testing vaccine versus viruses!");

                    // iterating over simpleDatabase
                    IDatabaseIterator iter = simpleDatabase.GetIterator(genomeDatabase);
                    while(iter.MoveNext())
                    {
                        foreach (var subject in subjects)
                        {
                            subject.GetTested((VirusData)iter.Current);
                        }
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();

            IDatabaseIterator iter;
            Console.WriteLine("\nPlain output of simpleDatabase:");
            iter = simpleDatabase.GetIterator(genomeDatabase);
            mediaOutlet.Publish(iter);

            Console.WriteLine("\nPlain output of excellDatabase:");
            iter = excellDatabase.GetIterator(genomeDatabase);
            mediaOutlet.Publish(iter);

            Console.WriteLine("\nPlain output of overcomplicatedDatabase:");
            iter = overcomplicatedDatabase.GetIterator(genomeDatabase);
            mediaOutlet.Publish(iter);

            // Decorating iterators
            Console.WriteLine("\nFiltered excel: (Death rate > 15 only)");
            iter = excellDatabase.GetIterator(genomeDatabase);
            iter = new FilterIterator(iter, f => f.DeathRate > 15);
            mediaOutlet.Publish(iter);

            Console.WriteLine("\nFiltered excel: (Mapping, then filter)");
            iter = excellDatabase.GetIterator(genomeDatabase);
            iter = new MappingIterator(iter, f => new VirusData(f.VirusName, f.DeathRate + 10, f.InfectionRate, f.Genomes));
            iter = new FilterIterator(iter, f => f.DeathRate > 15);
            mediaOutlet.Publish(iter);

            Console.WriteLine("\nConcatenation of Excel and Overcomplicated databases.");
            IDatabaseIterator iter1 = excellDatabase.GetIterator(genomeDatabase);
            IDatabaseIterator iter2 = overcomplicatedDatabase.GetIterator(genomeDatabase);
            iter = new ConcatIterator(iter1, iter2);
            mediaOutlet.Publish(iter);

            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
