using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String
    {

        static String()
        {
            Contains();
            IndexOf();
            SubStr();
            Compare();
        }

        //ref: word sort rules, not ordinal
        private static void Compare()
        {
            string s1 = "abc";
            string s2 = "ABC";
            int result;
            result = string.Compare(s1, s2);
            Console.WriteLine("Result {0}", result);
        }

        static void Contains()
        {
            string s = "abcd";
            Console.WriteLine("abcd contains ab {0}", s.Contains("ab"));

            Console.WriteLine("abcd contains abcde {0}", "abcd".Contains("abcde"));
        }

        static void IndexOf()
        {
            string s = "now it the time";
            Console.WriteLine("the appears in: {0} at pos: {1}", s, s.IndexOf("the"));
        }

        static void SubStr()
        {
            string s = "this is a test";
            Console.WriteLine("In: {0} at pos: 5, 2, found: {1}", s,  s.Substring(5, 2));
        }
    }

}
