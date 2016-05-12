﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class File
    {
        static string FilePath = "tst.txt";

        static File()
        {
            Create();
            Delete();
            Write();
            Read();
            Delete();
        }

/*
 * This is pretty straightforward using the File class.

if(File.Exists(@"C:\test.txt"))
{
    File.Delete(@"C:\test.txt");
}
you don't actually need to do the File.Exists check since File.
Delete doesn't throw an exception if the file doesn't exist, 
although if you're using absolute paths you will need the check to make sure the entire file path is valid.
The test is necessary if you want to prevent a possible DirectoryNotFoundException.
The test shouldn't be used in place of exception handling tho, but rather in conduction with it. Any number of scenarios can result in the exists check returning true and Delete throwing.
*/
        private static void Delete()
        {
            try
            {
                System.IO.File.Delete(FilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete file, error: {0}", e.Message);
            }
        }


        /*
        What is different between FileStream and StreamWriter in dotnet?
        A FileStream is a Stream. Like all Streams it only deals with byte[] data.

        A StreamWriter is a TextWriter, a Stream-decorator. A TextWriter converts or encodes Text data like string or char to byte[] and then writes it to the linked Stream.

        What context are you supposed to use it? What is their advantage and disadvantage?
        You use a bare FileStream when you have byte[] data. You add a StreamWriter when you want to write text.

        Is it possible to combine these two into one?
        Yes. You always need a Stream to create a StreamWriter. System.IO.File.CreateText("path") will create them in combination and then you only have to Dispose() the outer writer.
        */
        private static void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string ln;
                    while ((ln = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0} reading file: {1}: ", e.Message, FilePath);
            }
        }

        private static void Write()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    string ln;
                    sw.AutoFlush = true;
                    for (int i = 0; i < 3; i++)
                    {
                        sw.WriteLine("line {0}", i);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0} reading file: {1}: ", e.Message, FilePath);
            }
        }

        private static void Create()
        {
            string fe = FileExists(FilePath);
            Console.WriteLine("Before: {0} {1}", FilePath, fe);

            FileStream fs = new FileStream(FilePath, FileMode.Create);

            fe = FileExists(FilePath);
            Console.WriteLine("After: {0} {1}", FilePath, fe);
            fs.Close(); //<========== (used by another process error, if open. there are also open modes to ctrl
        }

        static string FileExists(string path)
        {
            bool b = System.IO.File.Exists(path);
            if (b)
            {
                return "File Exists";
            }
            return "File does not Exists";
        }

    }

    class Dir
    {
        static Dir()
        {
            CurDir();
        }

        static void CurDir()
        {
            //this may not be where the exe is located
            Console.WriteLine("Current Directory {0}", Directory.GetCurrentDirectory());
        }

    }
}
