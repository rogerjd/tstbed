﻿using tstbed.Collections;
using tstbed.Directoy_File_Path;
using tstbed;
using tstbed.Http;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!, test bed");

//cmd ln args
//command line arguments
/*
args[0] contains the first command-line argument, not the program name.
To get the program's name or path, use Process.GetCurrentProcess().MainModule.FileName or AppDomain.CurrentDomain.FriendlyName.
*/
Console.WriteLine(args.Length);
//Console.WriteLine(args[0]);  // this is not the pgm name, see: launch.json and tasks.json
//Console.WriteLine(args[1]);


DateTimeTimeSpan.Test();

List.Test();
//StringTst.Test();
//DictionaryTester.Tester();

IO.Test();

tstbed.Lang.Cond.Main();

//File_tst.Test();
//Directory_tst.Test();
//Path_tst.Test();
//HashSetTst.Test();

new tstbed.Delegates();

tstbed.Collections.Array.Test();

StringTst.Test();

ProcessTester.Test();

HttpClientTst.Test();

EnumTst.Test();

/*
Yes, there is a default namespace for the Program.cs file. It is the global namespace, and it is present in every C# file. The global namespace contains all of the types that are not declared in a named namespace. Any identifier in the global namespace is available for use in a named namespace.

The following is an example of a Program.cs file that uses the global namespace:

C#
using System;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
        }
    }
}
Use code with caution. Learn more
In this example, the Program class is declared in the MyNamespace namespace. However, the Console class is declared in the global namespace. Therefore, the Console.WriteLine() method can be called from the Program class without specifying the namespace.

If you want to avoid using the global namespace, you can declare your own namespace for your types. For example, the following is an example of a Program.cs file that declares its own namespace:

C#
namespace MyProject
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
        }
    }
}
Use code with caution. Learn more
In this example, the Program class is declared in the MyProject namespace. Therefore, the Console class must be qualified with the namespace when it is used. For example, the following code would print "Hello, world!" to the console:

C#
MyProject.Console.WriteLine("Hello, world!");
*/
