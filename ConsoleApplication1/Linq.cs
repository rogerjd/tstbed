using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Linq
    {
        public static object DataContext { get; private set; }

        public static void Test()
        {
            Console.WriteLine("Linq ****");
            zipTst();
            //            DB();
            Any();
        }

        private static void Any()
        {
            Console.WriteLine("any **");
            ICollection<int> c = new List<int> { 1, 2, 3, 4, 5 };
            bool b = c.Any(i => i > 10);
            Console.WriteLine("  " + b);

            b = c.Any(i => i > 1);
            Console.WriteLine("  {0}", b);
        }

        static private void zipTst()
        {
            Console.WriteLine("zip **");
            List<string> l1 = new List<string> { "a", "b", "c" };
            List<string> l2 = new List<string> { "1", "2", "3" };

            var dic = l1.Zip(l2, (a, b) => new { b, a }).ToDictionary(x => x.b, x => x.a);
            foreach (var i in dic)
            {
                Console.WriteLine(i);
            }



//converts int to string automatically
            l1 = new List<string> { "a", "b", "c" };
            List<int> l3 = new List<int> { 1, 2, 3 };

            var l4 = l1.Zip(l2, (a, b) => a + " " + b );
            foreach (var s in l4)
            {
                Console.WriteLine(s);
            }
        }

        [Table]
        public class Movie
        {
            [Column]
            public int ID { get; set; }

            [Column]
            public string Title { get; set; }

            [Column]
            public DateTime ReleaseDate { get; set; }

            [Column]
            public string Genre { get; set; }

            [Column]
            public decimal Price { get; set; }

            [Column]
            public string Rating { get; set; }
        }

        static void DB()
        {
            string connStr = "Server=(localdb)\\mssqllocaldb;Database=aspnet5-MVCMovie-6ee74982-4ec3-47e0-b632-1729502aab6a;Trusted_Connection=True;MultipleActiveResultSets=true";
            //ref: the dc takes care of opening and closing the connection
            DataContext dc = new DataContext(connStr); //may need to manuall add reference: sys.data.linq 
            Table<Movie> movies = dc.GetTable<Movie>();
            foreach (Movie m in movies)
            {
                Console.WriteLine("Movie Title: {0}", m.Title);
            }
        }
    }
}
