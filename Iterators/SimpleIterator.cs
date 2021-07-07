using System;
using System.Collections.Generic;
using System.Text;
using Task3.Databases;
using System.Collections;

namespace Task3.Iterators
{
    public class SimpleIterator : IDatabaseIterator
    {
        readonly SimpleDatabase database;
        readonly SimpleGenomeDatabase genomeDatabase;
        int currentPosition = -1;

        public SimpleIterator(SimpleDatabase sdb, SimpleGenomeDatabase gdb)
        {
            database = sdb;
            genomeDatabase = gdb;
        }

        public bool MoveNext()
        {
            
            if (currentPosition + 1 >= 0 && currentPosition + 1 < database.Rows.Count)
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
                SimpleDatabaseRow r = database.Rows[currentPosition];
                List<GenomeData> genomes = new List<GenomeData>();
                foreach(var gd in genomeDatabase.genomeDatas)
                {
                    if (gd.Id == r.GenomeId)
                        genomes.Add(gd);
                }
                VirusData virus = new VirusData(r.VirusName, r.DeathRate, r.InfectionRate, genomes);
                return virus;
            }
        }
    }
}
