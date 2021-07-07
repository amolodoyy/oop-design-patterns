using System;
using System.Collections.Generic;
using System.Text;
using Task3.Iterators;

namespace Task3.Databases
{
    public abstract class Database
    {
        public abstract IDatabaseIterator GetIterator(SimpleGenomeDatabase database);
    }
}
