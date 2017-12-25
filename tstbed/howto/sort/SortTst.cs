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

            //linq
            var a2 = arrayOfCars.OrderBy(i => i.Make).ToArray();
            WriteArray("Sorted by Linq Make", a2);

            //mulitple cols: Var movies = _db.Movies.OrderBy(c => c.Category).ThenBy(n => n.Name)

            a2 = arrayOfCars.OrderByDescending(i => i.Year).ToArray();
            WriteArray("Sorted by Linq Year desc", a2);

            Array.Sort(arrayOfCars);

            WriteArray("Sorted by Make", arrayOfCars);

            Array.Sort(arrayOfCars, new car.SortYear()); //alt: use default param { _asc = true });
            WriteArray("Sorted by Year - asc", arrayOfCars);

            Array.Sort(arrayOfCars, new car.SortYear(false));
            WriteArray("Sorted by Year - desc", arrayOfCars);


            ////linq
            //var a2 = arrayOfCars.OrderBy(i => i.Make).ToList();
            //WriteArray("Sorted by Linq Make", arrayOfCars);
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
            public class SortYear : IComparer<car>
            {
                public bool _asc; //default = false

                //alt: use default param public SortYear() : this(true) { }
                public SortYear(bool asc = true)
                {
                    _asc = asc;
                }

                public int Compare(car c1, car c2)
                {
                    return c1.Year.CompareTo(c2.Year) * (_asc ? 1 : -1);
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
