using System;
using System.Collections.Generic;
using System.Text;
using Task3.Iterators;
using Task3.Decorators;
namespace Task3.Databases
{
    public static class IteratorCreator
    {
        public static SimpleIterator CreateSimpleIterator(SimpleDatabase db, SimpleGenomeDatabase gdb)
        {
            return new SimpleIterator(db,gdb);
        }
        public static ExcelIterator CreateExcelIterator(ExcellDatabase db, SimpleGenomeDatabase gdb)
        {
            return new ExcelIterator(db, gdb);
        }
        public static OvercomplicatedIterator CreateOvercomplicatedIterator(OvercomplicatedDatabase db, SimpleGenomeDatabase gdb)
        {
            return new OvercomplicatedIterator(db, gdb);
        }
        public static FilterIterator CreateFilterIterator(IDatabaseIterator iter, Func<VirusData, bool> f)
        {
            return new FilterIterator(iter, f);
        }
        public static MappingIterator CreateMappingIterator(IDatabaseIterator iter, Func<VirusData,VirusData> f)
        {
            return new MappingIterator(iter, f);
        }
        public static ConcatIterator CreateConcatIterator(IDatabaseIterator iterator1, IDatabaseIterator iterator2)
        {
            return new ConcatIterator(iterator1, iterator2);
        }
    }
}
