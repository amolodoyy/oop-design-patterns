using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Task3.Iterators
{
    public class OvercomplicatedIterator : IDatabaseIterator
    {
        private readonly SimpleGenomeDatabase genomeDatabase;
        private readonly OvercomplicatedDatabase overcomplicatedDB;
        private int currentPosition = -1;
        private List<INode> treeList = new List<INode>();
        public OvercomplicatedIterator(OvercomplicatedDatabase ovcdb, SimpleGenomeDatabase gdb)
        {
            overcomplicatedDB = ovcdb;
            genomeDatabase = gdb;
            treeToList();
        }
        public void treeToList()
        {
            Queue<INode> q = new Queue<INode>();
            q.Enqueue(overcomplicatedDB.Root);
            while(q.Count > 0)
            {
                INode node = q.Dequeue();
                treeList.Add(node);
                foreach(var n in node.Children)
                {
                    if (n != null)
                        q.Enqueue(n);
                }
            }
        }
        public bool MoveNext()
        {
            if (currentPosition + 1 >= 0 && currentPosition + 1 < treeList.Count)
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
                INode node = treeList[currentPosition];
                List<GenomeData> genomes = new List<GenomeData>();
                foreach (var gd in genomeDatabase.genomeDatas)
                {
                    foreach(var tag in gd.Tags)
                    {
                        if (tag == node.GenomeTag && genomes.Contains(gd) == false)
                            genomes.Add(gd);
                    }
                }
                VirusData virus = new VirusData(node.VirusName, node.DeathRate, node.InfectionRate, genomes);
                return virus;
            }
        }
    }
}
