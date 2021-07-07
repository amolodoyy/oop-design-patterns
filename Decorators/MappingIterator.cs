using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Task3.Iterators;
namespace Task3.Decorators
{
    public class MappingIterator : IDatabaseIterator
    {
        IDatabaseIterator mainIterator;
        Func<VirusData, VirusData> function;
        public MappingIterator(IDatabaseIterator iter, Func<VirusData, VirusData> func)
        {
            mainIterator = iter;
            function = func;
        }
        public bool MoveNext()
        {
            if (mainIterator.MoveNext())
                return true;
            return false;
        }
        public void Reset()
        {
            mainIterator.Reset();
        }
        object IEnumerator.Current
        {
            get
            {
                VirusData virus = (VirusData)mainIterator.Current;
                virus = function(virus);
                return virus;
            }
            
        }
    }
}
