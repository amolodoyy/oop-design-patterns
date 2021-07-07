using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Task3.Databases;
using System.Collections;
namespace Task3.Iterators
{
    public class ExcelIterator : IDatabaseIterator
    {

        int currentPosition = -1;
        readonly ExcellDatabase excellDatabase;
        readonly SimpleGenomeDatabase genomeDatabase;
        public ExcelIterator(ExcellDatabase exdb, SimpleGenomeDatabase sdb)
        {
            excellDatabase = exdb;
            genomeDatabase = sdb;
        }

        public bool MoveNext()
        {
            if(currentPosition + 1 >= 0 && currentPosition + 1 <= excellDatabase.Names.Count(x => x == ';'))
            {
                currentPosition++;
                return true;
            }
            return false;
        }
        public void Reset() 
        {
            currentPosition = -1;
        }
        object IEnumerator.Current
        {
            get
            {
                string[] names = excellDatabase.Names.Split(';');
                string name = names[currentPosition];
                string[] deathRates = excellDatabase.DeathRates.Split(';');
                double deathRate = Double.Parse(deathRates[currentPosition]);
                string[] infectionRates = excellDatabase.InfectionRates.Split(';');
                double infectionRate = Double.Parse(infectionRates[currentPosition]);
                string[] genomeIds = excellDatabase.GenomeIds.Split(';');
                Guid genomeId = Guid.Parse(genomeIds[currentPosition]);

                List<GenomeData> genomes = new List<GenomeData>();
                foreach(var g in genomeDatabase.genomeDatas)
                {
                    if (genomeId == g.Id)
                        genomes.Add(g);
                }
                VirusData virus = new VirusData(name, deathRate, infectionRate, genomes);
                return virus; 
            }
        }

    }

}
