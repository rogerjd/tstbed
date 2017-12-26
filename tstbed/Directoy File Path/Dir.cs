using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Directoy_File_Path
{
    class Dir
    {
        public static void Test()
        {
            CurDir();
            Contents();
        }

        private static void Contents()
        {
            void GetDirectories()
            {
                //returns string[] of directory names(full path) in that folder (only dirs, no files)
                //there are overloads, eg: sub dir search
                var dirs = Directory.GetDirectories(@"C:\prjs");
            }

            //2 ways shown
            void GetFiles()
            {
                Utils.WriteSubTopic("Dir GetFiles");
                if (Directory.Exists("."))
                {
                    string[] files = Directory.GetFiles(".");  //static,    string[]
                    foreach (string f in files)
                    {
                        Utils.WriteDetailLine(f);
                    }
                }

                DirectoryInfo di = new DirectoryInfo(".");  //instance,  FileInfo[]
                if (di.Exists)
                {
                    FileInfo[] files2 = di.GetFiles(".");
                    foreach (FileInfo fi in files2)
                    {
                        Utils.WriteDetailLine(fi.Name);
                    }
                }
            }

            GetDirectories();
            GetFiles();
        }

        static void CurDir()
        {
            //this may not be where the exe is located
            Console.WriteLine("Current Directory {0}", Directory.GetCurrentDirectory());
        }
    }

}
