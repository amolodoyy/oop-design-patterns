using System;
using System.Collections.Generic;
using System.Text;
using Task3.Iterators;
using System.Collections;
namespace Task3.Decorators
{
    public class FilterIterator : IDatabaseIterator
    {
        IDatabaseIterator mainIterator;
        Func<VirusData, bool> function;
        public FilterIterator(IDatabaseIterator iter, Func<VirusData, bool> func) 
        {
            mainIterator = iter;
            function = func;
        }
        public bool MoveNext() 
        {
            if(mainIterator.MoveNext()) 
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
                if(function((VirusData)mainIterator.Current))
                {
                    return mainIterator.Current;
                }
                return null;
            }
        }
    }
}
