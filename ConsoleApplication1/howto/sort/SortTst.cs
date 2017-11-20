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

            WriteArray("Sorted by Make", arrayOfCars);

            Array.Sort(arrayOfCars, new car.SortYear());
            WriteArray("Sorted by Year", arrayOfCars);
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
            public class SortYear: IComparer<car>
            {
                public int Compare(car c1, car c2)
                {
                    return c1.Year.CompareTo(c2.Year);
                }
            }

            public int CompareTo(car other)
            {
                return string.Compare(Make, other.Make);
            }

            //todo: make IComparer (class), to sort by Year asc/desc
            //https://support.microsoft.com/en-us/help/320727/how-to-use-the-icomparable-and-icomparer-interfaces-in-visual-c

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
