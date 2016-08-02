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
            Console.WriteLine("STRING TESTS ****");

            Contains();
            IndexOf();
            SubStr();
            Compare();
            Concatenate();
            Replace();
            SplitIntoArray();
        }

        //array, convert to
        //note:  For strings delimited by a pattern(ie: any number of spaces) rather than a value, RegEx is a great (well, the only) option
        private static void SplitIntoArray()
        {
            Console.WriteLine("split into array **");

            //ref: leading/trailing delims will result in an empty string added to the array
            string s = "abc def ghi";
            string[] res = s.Split(' ');
            foreach (string i in res)
            {
                Console.WriteLine("{0} {1}", i, i.Length);
            }

            //use string, not char
            string[] res2 = s.Split(new string[] {"def"}, StringSplitOptions.None);
            foreach (string i in res2)
            {
                Console.WriteLine("{0} {1}", i, i.Length);
            }


        }

        //ref: replace all occurrences
        private static void Replace()
        {
            Console.WriteLine("replace ***");

            string s1 = "the is the was the then";
            string s2 = string.Empty;

            s2 = s1.Replace("the", "abc");
            Console.WriteLine(s2);

            //to replace only first, do it yourself
            s1 = s1.ReplaceFirst("the", "and");
            Console.WriteLine(s1);
        }

        private static void Concatenate()
        {
            Console.WriteLine("concat");
            string s1 = "abc";
            string s2 = "def";
            Console.WriteLine(s1 + s2);
        }

        //ref: word sort rules, not ordinal
        private static void Compare()
        {
            string s1 = "abc";
            string s2 = "ABC";
            int result;
            result = string.Compare(s1, s2);
            Console.WriteLine("Result {0}", result);
            Console.WriteLine(s1 == s2);
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
            Console.WriteLine("In: {0} at pos: 5, 2, found: {1}", s, s.Substring(5, 2));
        }
    }

    static class StringUtils
    {
        public static string ReplaceFirst(this string tgt, string oldStr, string newStr)
        {
            int pos = tgt.IndexOf(oldStr);

            if (pos == -1)
            {
                return tgt;
            }

            return tgt.Substring(0, pos) + newStr + tgt.Substring(pos + oldStr.Length);
        }
    }
}
