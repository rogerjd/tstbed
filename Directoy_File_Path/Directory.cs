using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tstbed.Directoy_File_Path
{
    static public class Directory_tst
    {
        static public void Test()
        {
            Hello();
            ReadAllFiles();
        }

        private static void ReadAllFiles()
        {
            string[] files = Directory.GetFiles(".");
            Console.WriteLine("Number of files in directory: " + files.Length.ToString());

            DirectoryInfo di = new DirectoryInfo(".");
            FileInfo[] fis = di.GetFiles();
            Console.WriteLine("Number of files in directory, FileInfo: " + fis.Length.ToString());
        }

        private static void Hello()
        {
            Console.WriteLine("Hello: Directory test");
        }
    }
}