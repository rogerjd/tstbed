using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.howto.sort
{
    static class SortTst
    {
        public static void Test()
        {
            Utils.WriteTopic("how to sort");

            car[] arrayOfCars = new car[6]
            {
                new car("Ford", 1992),
                new car("Fiat", 1988),
                new car("Buick", 1932),
                new car("Ford", 1932),
                new car("Dodge", 1999),
                new car("Honda", 1977)
            };
            WriteArray("Array - Unsorted", arrayOfCars);
        }

        static void WriteArray(string hdr, car[] cars)
        {
            Utils.WriteSubTopic(hdr);
            foreach (car c in cars)
            {
                Utils.WriteDetailLine(c.Make + "\t\t" + c.Year);
            }
        }

        class car : IComparable
        {
            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }

            public int Year { get; set; }
            public string Make { get; set; }

            internal car(string make, int year)
            {
                Make = make;
                Year = year;
            }
        }

    }
}
