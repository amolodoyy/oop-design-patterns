using System;
using System.Collections.Generic;
using System.Collections;
using Task3.Databases;
using Task3.Iterators;

namespace Task3
{
    public class ExcellDatabase : Database
    {
        public string Names { get; }
        public string DeathRates { get; }
        public string InfectionRates { get; }
        public string GenomeIds { get; }

        public ExcellDatabase(string names, string deathRates, string infectionRates, string genomeIds)
        {
            Names = names;
            DeathRates = deathRates;
            InfectionRates = infectionRates;
            GenomeIds = genomeIds;
        }
        public override IDatabaseIterator GetIterator(SimpleGenomeDatabase sdb)
        {
            return new ExcelIterator(this, sdb);
        }
    }

    public class SimpleDatabaseRow
    {
        public string VirusName { get; set; }
        public double DeathRate { get; set; }
        public double InfectionRate { get; set; }
        public Guid GenomeId { get; set; }
    }

    public class SimpleDatabase : Database
    {
        public IReadOnlyList<SimpleDatabaseRow> Rows { get; }
        public SimpleDatabase(IEnumerable<SimpleDatabaseRow> simpleDatabaseRows)
        {
            var list = new List<SimpleDatabaseRow>();
            list.AddRange(simpleDatabaseRows);

            Rows = list;
        }
        public override IDatabaseIterator GetIterator(SimpleGenomeDatabase sdb)
        {
            return new SimpleIterator(this, sdb);
        }
    }
}
