using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Task3.Iterators;
using Task3.Databases;
 
namespace Task3.Decorators
{
    public class ConcatIterator : IDatabaseIterator
    {
        private IDatabaseIterator iterator1, iterator2;
        private bool location = false; // false - we are in 1 db, true - in 2
        public ConcatIterator(IDatabaseIterator iter1, IDatabaseIterator iter2)
        {
            iterator1 = iter1;
            iterator2 = iter2;
        }
        public bool MoveNext()
        {
            if (iterator1.MoveNext())
                return true;
            else if (iterator1.MoveNext() == false && iterator2.MoveNext() == true)
            {
                location = true;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            if (iterator1.Current != null)
                iterator1.Reset();
            else
                iterator2.Reset();
        }
        object IEnumerator.Current
        {
            get
            {
                if (location == false)
                    return iterator1.Current;
                else
                    return iterator2.Current;
            }

        }
    }
}
