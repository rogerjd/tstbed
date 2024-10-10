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
            CurrentPath();
            OpenAndRead();
            Copy();
            Length();
            Rename();
            Delete();

            csv_file.Read();

            FileDateTimeAnMore();
        }

        private static void FileDateTimeAnMore()
        {
            FileInfo fi = new FileInfo("WriteAllLns.txt");
            Console.WriteLine(fi.LastAccessTime);
            Console.WriteLine(fi.LastWriteTime);

            Console.WriteLine(fi.Extension);
            Console.WriteLine(fi.Name);
            Console.WriteLine(fi.FullName);
        }

        /*
        Current Working Directory vs. Executable Path:
        Directory.GetCurrentDirectory() gives you the working directory at the time your 
            application starts. In Visual Studio Code (VSC), the working directory is 
            typically the root of your project when running or debugging, because that's 
            where the terminal or debug configuration starts the application from.
        */
        private static void CurrentPath()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        private static void Delete()
        {
            File.Delete("b.txt"); //todo: test
        }

        //todo: test
        private static void Rename()
        {
            if (!File.Exists("a.txt"))
            {
                //FileStream fs = File.Create("a.txt"); // create or overwrite
                StreamWriter sw = new StreamWriter("a.txt");
                sw.WriteLine("my file");
                sw.Close();

            }
            File.Move("a.txt", "b.txt", true);  // src, dst, overwrite
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
        private static void OpenAndRead()
        {
            void ReadLineByLine()
            {
                if (File.Exists("WriteAllLns.txt"))
                {
                    using System.IO.StreamReader file = new StreamReader("WriteAllLns.txt");
                    string? ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        Utils.WriteDetailLine(ln);
                    }
                }

                var txt = File.ReadAllText("WriteAllLns.txt");
                // there is also File.WriteAllText();
            }

            void ReadAllLines()
            {
                //chk if File.Exists first
                string[] lns = File.ReadAllLines("WriteAllLns.txt");
                //can put into a List<string>
            }

            ReadAllLines();

            ReadLineByLine();

            // opens file, reads all text, then closes file
            string fileContents = File.ReadAllText("WriteAllLns.txt");
            Console.WriteLine(fileContents);
        }

    }
}
