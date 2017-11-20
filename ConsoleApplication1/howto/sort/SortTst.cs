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

            Array.Sort(arrayOfCars);

            WriteArray("Sorted", arrayOfCars);
        }

        static void WriteArray(string hdr, car[] cars)
        {
            Utils.WriteSubTopic(hdr);
            foreach (car c in cars)
            {
                Utils.WriteDetailLine(c.Make + "\t\t" + c.Year);
            }
        }

        class car : IComparable<car>
        {
            public int CompareTo(car other)
            {
                return string.Compare(Make, other.Make);
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
