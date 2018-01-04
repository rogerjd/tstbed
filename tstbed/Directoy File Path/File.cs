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
        }

        private static void Copy()
        {
            string inFile, outFile;
            inFile = @"c:\temp\testfile.txt";
            outFile = @"c:\temp\testfile_copy.txt";
            //will raise exception if File already exists
            File.Copy(inFile, outFile); //params are strings

        }

        private static void Read()
        {
            void ReadAllLines()
            {
                string[] lns = File.ReadAllLines("WriteAllLns.txt");
                //can put into a List<string>
            }

            ReadAllLines();
        }
    }
}
