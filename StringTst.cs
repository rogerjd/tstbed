namespace tstbed
{

    public static class StringTst
    {
        public static void Test()
        {
            Utils.WriteTopic("string tester");

            Interpolation(); //concat

            Insert();
            Remove();
            Replace();
            ConcatJoin();
            Substring();
            IndexOf();
            Compare();
        }

        private static void IndexOf()
        {
            string str = "Hello, World!";
            int n = str.IndexOf("W");
            Console.WriteLine(n);
        }

        private static void Substring()
        {
            string str = "Hello, World!";
            Console.WriteLine(str.Substring(7, 5)); // start index, len
            Console.WriteLine(str.Substring(7)); // start index (to end)
        }

        //substring
        //index
        //contains
        //format
        //to int
        //substring

        /*
            AssignmentByValImmutable();
            Contains();
            StartsWith();
            EndsWith();
            IndexOf();
            SubStr();
            Compare();
            Concatenate();
            Replace();
            SplitIntoArrayJoin();
            Interpolation();
            EmptyNullWhitespace();
            Escape();
            //Trim TrimStart TrimEnd
            Trim();

            //Remove  delete
            //Join
            //Split
            //Length property
            Format();
            Equals();
        */
        private static void Interpolation()
        {
            Console.WriteLine("concat");
            string s1 = "abc";
            string s2 = "def";  //concat
            Console.WriteLine($"{s1} + {s2} = {s1 + s2}");
        }

        static void Insert()
        {
            Console.WriteLine("insert");
            string s1 = "abc";
            string s2 = "Z";
            string s3 = s1.Insert(1, s2);
            Console.WriteLine($" Insert {s2} in {s1} at pos 1 = {s3}");
        }

        static void Remove()
        {
            string s1 = "abc";
            string s2 = s1.Remove(1, 1);
            Console.WriteLine($"Remove from {s1} at pos 1 len 1 = {s2}");
        }

        static void Replace()
        {
            string s1 = "abcabc";
            Console.WriteLine(s1);
            string s2 = s1.Replace("a", "b");
            Console.WriteLine(s2);
        }

        static void ConcatJoin()
        {
            string s1 = "abc";
            string s2 = "def";
            string s3 = s1 + s2;
            Console.WriteLine(s3);

            // The main difference between String.Join() and String.Concat() is that 
            //   String.Join() takes a delimiter as an argument, while String.Concat() 
            //   does not. This means that String.Join() can be used to concatenate strings 
            //   with a delimiter between them, while String.Concat() can only be used to 
            //   concatenate strings without a delimiter.
            //   String.Join() is generally faster than String.Concat(), especially 
            //   when concatenating a large number of strings. This is because 
            //   String.Join() uses a StringBuilder internally, which is more 
            //   efficient than concatenating strings one at a time.            

            var strings = new[] { "Hello", "World" };
            string res = string.Concat(strings);
            Console.WriteLine(res);
            res = string.Join(", ", strings);
            Console.WriteLine(res);
            res = string.Join("", strings);
            Console.WriteLine(res);
        }

        static void Compare()
        {
            string str1 = "abc";
            string str2 = "ABC";
            int n = string.Compare(str1, str2, true); // ignoreCase true (bol) -1, 0, 1 (1st is: <, =, >. compared to 2nd)
            Console.WriteLine(n);

            bool res = str1.Equals(str2); // this is case-sens
            Console.WriteLine(res);
            res = str1.Equals(str2, StringComparison.CurrentCultureIgnoreCase); // this is not case-sens
            Console.WriteLine(res);

            res = str1 == str2;
            Console.WriteLine(res);
        }
    }
}

