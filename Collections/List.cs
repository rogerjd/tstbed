

namespace tstbed.Collections
{

    class Student
    {
        public int Grade { get; set; }
        public string Name { get; set; }
    }

    class StudentComparer : IComparer<Student>
    {
        public enum SortBy
        {
            Grade,
            Name
        }

        public SortBy sortBy;

        public int Compare(Student? x, Student? y)
        {
            switch (sortBy)
            {
                case SortBy.Grade: return x.Grade.CompareTo(y.Grade);
                case SortBy.Name: return x.Name.CompareTo(y.Name);
                default: return 0;
            }
        }
    }

    static class List
    {
        static List<string> l = new List<string> { "z", "a", "b", "c" };

        public static void Test()
        {
            Utils.WriteTopic("List tester");

            FromRange();
            Count();
            Sort();
            Foreach();
            Modify();
            Indexer();
            Find();
            Index();
            Dups();
            Insert();
            Remove();
            RemoveAt();
            FindAll();
            WriteAsString();
            WriteToFile();
            ReadFromFile();
            Capacity();
            AddRange();
            Any();
            RemoveAll();
            Sum();
            SortStudent();
        }

        private static void Index()
        {
            Utils.WriteSubTopic("IndexOf");

            Utils.WriteDetailLine($" x =  {l.IndexOf("x")}");
            Utils.WriteDetailLine($" z = {l.IndexOf("z")}");
            Utils.WriteDetailLine($" c = {l.IndexOf("c")}");
        }

        private static void SortStudent()
        {
            //set notes below, Linq etc
            List<Student> stds = new List<Student> { new Student(){Grade = 6, Name = "Abc"},
            new Student(){Grade = 5, Name = "Jkl"} }; // collection initializer

            var SrtdStds = stds.OrderBy(s => s.Grade).ToList();
            foreach (var std in SrtdStds)
            {
                Console.WriteLine($"{std.Name} {std.Grade}");
            }

            StudentComparer cmp = new StudentComparer() { sortBy = StudentComparer.SortBy.Grade };
            stds.Sort(cmp);
            foreach (var std in stds)
            {
                Console.WriteLine($"{std.Name} {std.Grade}");
            }
        }

        private static void FromRange()
        {                            //start at: 2, length of list: 10
            List<int> n = Enumerable.Range(2, 10).ToList();
        }

        private static void Any()
        {
            Utils.WriteSubTopic("Any");
            string s = "";
            if (l.Any(x =>
            {
                var z = string.Compare(x, "c") == -1;
                s = x;
                return z; //if it's just one line (compare) don't need return
            }))
            {
                Utils.WriteDetailLine("some are less than c  " + s);
            }
        }

        private static void RemoveAll()
        {
            void WriteList()
            {
                foreach (var s in l)
                {
                    Utils.WriteDetailLine(s);
                }
            }

            WriteList();
            var n = l.RemoveAll(x => string.Compare(x, "c") == -1);
            Utils.WriteDetailLine($"{n} items removed");
            WriteList();
        }

        private static void AddRange()
        {
            Utils.WriteSubTopic("Add Range");
            List<int> l = new List<int> { 1, 2, 3 };
            Utils.WriteDetailLine("before join: " + string.Join(",", l));

            int[] n = new int[] { 4, 5, 6 };
            l.AddRange(n);
            Utils.WriteDetailLine("after join: " + string.Join(",", l));
        }

        private static void Remove()
        {
            l.Remove("zz");
            //If type T implements the IEquatable<T> generic interface, the equality comparer is the Equals method of that interface; otherwise, the default equality comparer is Object.Equals.
        }

        private static void Insert()
        {
            /*
                        Assert.Equal(l.Count, 4);
                        l.Insert(2, "zy");
                        Assert.Equal(l[2], "zy");
                        Assert.Equal(l[3], "b");
                        Assert.Equal(l.Count, 5);
                */
        }

        private static void Capacity()
        {
            /* see Count, TrimExcess
             * Resize
             * 
             */
        }

        private static void WriteAsString()
        {
            Console.WriteLine(string.Join(" ", l));
            //l.ToString
        }

        //SaveToFile
        private static void WriteToFile()
        {
            //see: File.WriteAllLines
        }

        //LoadFromFile
        private static void ReadFromFile()
        {
            //see: File.ReadAllLines
        }

        private static void FindAll()
        {
            Utils.WriteSubTopic("FindAll");

            bool ContainsVowel(string s)
            {
                foreach (char c in s)
                {
                    if ("aeiouAEIOU".Contains(c))
                    {
                        return true;
                    }
                }
                return false;
                //todo: return "aeiouAEIOU".Contains(s);
            }

            var l2 = from x in l
                     where ContainsVowel(x)
                     select x;
            Console.WriteLine(string.Join(" ", l2));

            var l3 = l.Where(p => p == "a");
            Console.WriteLine(string.Join(" ", l3));

            List<string> l4 = l.FindAll(x => x.CompareTo("b") > 0);
            l4[0] = "zz"; //this is new string (immutable)
            Console.WriteLine(string.Join(" ", l));
            Utils.WriteDetailLine("l4[0] == l[0]: " + (l4[0].CompareTo(l[0]) == 0).ToString());
        }

        //bug
        private static void RemoveAt()
        {
            List<int> l = new List<int> { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < l.Count - 1; i++)
            {
                l.RemoveAt(i);
            }
        }

        private static void Dups()
        {
            //must do yourself
            /*
            public static bool AreAnyDuplicates<T>(this IEnumerable<T> list)
            {
                var hashset = new HashSet<T>();
                return list.Any(e => !hashset.Add(e));
            }
            */
        }

        private static void Find()
        {
            Utils.WriteSubTopic("Find");
            Console.WriteLine(l.Contains("z"));

            //ref: predicate
            //      return is not bool, but the item
            Console.WriteLine(l.Find(List.Finder));
            //string res = l.Find(s => { return s == "a"; });
            //Console.WriteLine(res);
            //res = "wqwq";
            Foreach();
        }

        static bool Finder(string s)
        {
            return s == "zx";
        }

        private static void Indexer()
        {
            Utils.WriteSubTopic("Indexer");

            Console.WriteLine(l[0]);
            l[0] = "new";
            Console.WriteLine(l[0]);
        }

        private static void Modify()
        {
            Utils.WriteSubTopic("Modify");

            //ref: one at a time
            Count();
            l.Add("xyz");
            Count();
            var b = l.Remove("xyz");
            Count();
            Console.WriteLine(b);

            //ref: many
            l.AddRange(new List<string> { "1", "2", "3" });
            Count();

            l.RemoveRange(l.Count() - 3, 3);
            Count();
        }

        private static void Foreach()
        {
            Utils.WriteSubTopic("Foreach");

            foreach (System.String s in l)
            {
                Console.WriteLine(s);
            }
        }

        //- pass into l.Sort()
        //      1 - nothing, uses default comparer
        //      2 = Comparison  delegate
        //      3 = an IComparer
        //- l.Reverse
        private static void Sort()
        {
            int comparison(string a, string b)
            {
                // leave out special cases
                return a.CompareTo(b);
            }

            Utils.WriteSubTopic("Sort");

            //default ///////// primitive
            l.Sort();
            Console.WriteLine(string.Join(" ", l));

            l.Reverse();
            Console.WriteLine(string.Join(" ", l));

            //use Comparison delegate
            List<string> l2 = new List<string> { "abc, xyz0", "qrs, def9" };
            l2.Sort((a, b) => a.Substring(5, 3).CompareTo(b.Substring(5, 3)));
            Console.WriteLine(string.Join(" ", l2));

            //use Comparer IComparer (it is class, w/method)
            l2.Sort(new MyComparer());
            Console.WriteLine(string.Join(" ", l2));

            List<string> l3 = new List<string> { "z, xyz0", "b", "s" };
            l3.Sort(comparison);  // new way, sort proc, 3/28/24    public delegate int Comparison<in T>(T x, T y);
            Console.WriteLine(string.Join(" ", l3));
        }

        private static void Count()
        {
            Utils.WriteSubTopic("Count");
            int n = l.Count();
            Console.WriteLine(n);
        }

        static void Sum()
        {
            var l = new List<int>() { 1, 2, 3 };
            Console.WriteLine($"Sum: {l.Sum()}");
        }
    }

    class MyComparer : Comparer<string>
    {
        public override int Compare(string? x, string? y)
        {
            if (x == null) //todo: is this right?
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            return x.Substring(8, 1).CompareTo(y.Substring(8, 1));
        }
    }
}

/*
Both `LINQ` and `IComparer` are excellent options for sorting a list in C#, but the choice depends on your specific requirements and preferences.

### Option 1: Using LINQ (`OrderBy` or `OrderByDescending`)

LINQ is often the most concise and readable way to sort a list. If you want to keep the original list unsorted and work with a sorted version of it, LINQ is a great option.

Example:
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    public static void Main()
    {
        var students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20 },
            new Student { Name = "Bob", Age = 22 },
            new Student { Name = "Charlie", Age = 18 }
        };

        // Sort by Age using LINQ
        var sortedStudents = students.OrderBy(s => s.Age).ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name}, Age: {student.Age}");
        }
    }
}
```

In this case, `OrderBy(s => s.Age)` sorts by age in ascending order, and `ToList()` creates a sorted copy of the original list.

### Option 2: Using `IComparer` with `List.Sort`

If you need to sort the list in place (modifying the original list), `List.Sort` with an `IComparer` is a good choice. You can define a custom comparer to control the sorting criteria.

Example:
```csharp
using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class StudentAgeComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        return x.Age.CompareTo(y.Age); // Ascending order
    }
}

public class Program
{
    public static void Main()
    {
        var students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20 },
            new Student { Name = "Bob", Age = 22 },
            new Student { Name = "Charlie", Age = 18 }
        };

        // Sort in-place using IComparer
        students.Sort(new StudentAgeComparer());

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}, Age: {student.Age}");
        }
    }
}
```

Here, the `StudentAgeComparer` defines the sorting logic. Using `students.Sort(new StudentAgeComparer())` sorts the original list in place by age in ascending order.

### Summary

- **Use LINQ** if you want a concise, readable way to get a sorted copy of the list without modifying the original list.
- **Use `IComparer` with `List.Sort`** if you need to sort the list in place or want more control over the sorting logic. 

Both approaches are perfectly valid, so choose the one that best suits your needs!
*/
