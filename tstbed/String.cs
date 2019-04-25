using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    class StringTst
    {
        //It is immutable
        //   so, x = "abc"  then x = "def"    def in entirely new string (abc is unchanged)

        //It's a reference type.
        //It can't be a value-type, as value-types need a known size for the stack etc. As a reference-type, the size of the reference is known in advance, even if the size of the string isn't.
        //It behaves like you expect a value-type to behave because it is immutable; i.e.it doesn't* change once created. But there are lots of other immutable reference-types. Delegate instances, for example.
        //*=except for inside StringBuilder, but you never see it while it is doing this...

        //a collection of chars: foreach(char c in str)

        public static void Test()
        {
            Utils.WriteTopic("STRING TESTS");

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
        }

        private static void Trim()
        {
            char[] charsToTrim = { '.', ',' };

            string str = ".txt";
            str = str.Trim('.'); //can use array: charsToTrim
        }

        private static void Equals()
        {
            Utils.WriteSubTopic("Equals");
            string str = "abd";
            Utils.WriteDetailLine("abd == abc: " + str.Equals("abc"));
            Utils.WriteDetailLine("abd == abc: " + (str == "abc"));
            Utils.WriteDetailLine("abd != abc: " + (str != "abc"));
        }

        private static void Format()
        {
            Utils.WriteSubTopic("Format");
            string str = String.Format("{0:c}", 1.56); //currency, money //round to 2 places
            Utils.WriteDetailLine(str);
            
            //currency, money //round to 2 places
            str = String.Format("{0:c}", 1.569); 
            Utils.WriteDetailLine(str);

            //upper case C (same as lower case)
            str = String.Format("{0:C}", 1.569);
            Utils.WriteDetailLine(str);

            str = string.Format($"{3}");
            Utils.WriteDetailLine(str);

            var p1 = "param";
            str = string.Format($"LIKE '{p1}%'");
            Utils.WriteDetailLine(str);
        }

        private static void StartsWith()
        {
            //
        }

        private static void Escape()
        {
            Utils.WriteSubTopic("Escape");
            string str = "\'  \"  \\  \b  \n  \t";
            Utils.WriteDetailLine(str);
        }

        private static void EmptyNullWhitespace()
        {
            Utils.WriteSubTopic("Empty Null");
            string str = "";
            Utils.WriteDetailLine("is empty: " + (str == String.Empty));
            Utils.WriteDetailLine("is null empty: " + String.IsNullOrEmpty(str));
            Utils.WriteDetailLine("is null whitespace: " + String.IsNullOrWhiteSpace(str)); //done by char.IsWhiteSpace()
        }

        private static void AssignmentByValImmutable()
        {
            Utils.WriteSubTopic("Assignment by value"); //string is immutable
            string a, b;
            a = "abc";
            b = a;
            Utils.WriteDetailLine((a.CompareTo(b) == 0).ToString());
            b = "def"; //string is immutable; makes new string/new memory
            Utils.WriteDetailLine((a.CompareTo(b) == 0).ToString());
        }

        private static void Interpolation()
        {
            Console.WriteLine("  Interpolation**");
            var d = "def";
            var s = $"abc {d}";
            Console.WriteLine("    {0}", s);
        }

        private static void EndsWith()
        {
        }

        //array, convert to
        //note:  For strings delimited by a pattern(ie: any number of spaces) rather than a value, RegEx is a great (well, the only) option
        //       Empty string "" is returned for: delimitters at begin/end and adjacent ones
        private static void SplitIntoArrayJoin()
        {
            Utils.WriteSubTopic("Split Join");
            //            Console.WriteLine("  split into array **");

            //ref: leading/trailing delims will result in an empty string added to the array
            string s = "abc def ghi";
            string[] res = s.Split(' ');
            foreach (string i in res)
            {
                Utils.WriteDetailLine(i.ToString() + " " + i.Length.ToString());
            }

            //use string, not char
            string[] res2 = s.Split(new string[] { "def" }, StringSplitOptions.None);
            foreach (string i in res2)
            {
                Utils.WriteDetailLine(i.ToString() + " " + i.Length.ToString());
            }

            Utils.WriteDetailLine("Join: " + string.Join(";", res));
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
            Utils.WriteSubTopic("Compare");
            string s1 = "abc";
            string s2 = "ABC";
            int result;
            result = string.Compare(s1, s2);
            Console.WriteLine("Result {0}", result);
            Console.WriteLine(s1 == s2);

            ////////////////////////////////
            StringComparer scmp = StringComparer.CurrentCultureIgnoreCase;
            result = scmp.Compare(s1, s2);
            Utils.WriteDetailLine(result.ToString());

            /////////////////////////////////////
            //StringComparison.  is an enum

            ////////////////////////////////////
            scmp = StringComparer.Ordinal;
            result = scmp.Compare(s1, s2);
            Utils.WriteDetailLine(result.ToString()); //32, 97 - 65 = 32
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
            Console.WriteLine("'the' appears in: {0} at pos: {1}", s, s.IndexOf("the"));
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
