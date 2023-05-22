namespace tstbed
{

    public static class StringTst
    {
        public static void Test()
        {
            Utils.WriteTopic("string tester");

            //concat
            Concatenate(); //string interpolation

            Insert();
        }



        //substring
        //index
        //contains
        //format
        //to int
        //substring
        //insert

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
        private static void Concatenate()
        {
            Console.WriteLine("concat");
            string s1 = "abc";
            string s2 = "def";
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
    }
}

