using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Directoy_File_Path
{
    static class File_tst
    {
        static public void Test()
        {
            Read();
            Copy();
            Length();
        }

        private static void Length()
        {
            Utils.WriteDetailLine(new FileInfo("WriteAllLns.txt").Length.ToString());

            var fi = new FileInfo("WriteAllLns.txt");
//            fi.
        }

        private static void Copy()
        {
            string inFile, outFile;
            inFile = @"c:\temp\testfile.txt";
            outFile = @"c:\temp\testfile_copy.txt";
            //will raise exception if File already exists, unless overwrite param is True
            File.Copy(inFile, outFile, true); //params are strings
        }

        /* 2 ways:
             - whole thing at once StringList
             - or line by line
        */
        private static void Read()
        {
            void ReadLineByLine()
            {
                using (System.IO.StreamReader file = new StreamReader("WriteAllLns.txt"))
                {
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        Utils.WriteDetailLine(ln);
                    }
                }

            }

            void ReadAllLines()
            {
                string[] lns = File.ReadAllLines("WriteAllLns.txt");
                //can put into a List<string>
            }

            ReadAllLines();

            ReadLineByLine();
        }

    }
}
