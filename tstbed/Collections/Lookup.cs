using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Collections
{
    //like Dictionary, but can have multiple items per key
    //IGrouping
    static class Lookup
    {
        class Package
        {
            public string Company;
            public double Weight;
            public long TrackingNumber;
        }

        static Lookup<char, string> lookup;
        public static void Test()
        {
            // ctor
            Create();
        }

        private static void Create()
        {
            /* ctor
            Per MSDN documentation, there is no public constructor for the Lookup class: http://msdn.microsoft.com/en-us/library/bb460184.aspx
            You can create an instance of a Lookup<TKey, TElement> by calling ToLookup on an object that implements IEnumerable<T>.
            */

            List<Package> packages = new List<Package> {
                new Package { Company = "Coho Vienyard", Weight = 25.2, TrackingNumber = 89453312L},
                new Package{Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L},
                new Package{Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L},
                new Package{Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L},
                new Package{Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L} };
        }
    }
}
