using System.Diagnostics;

namespace tstbed
{

    public static class ProcessTester
    {
        public static void Test()
        {
            ProcessTst();
        }


        // "console": "internalConsole",  worked with this
        static void ProcessTst()
        {
            // this worked
            //https://learn.microsoft.com/en-us/answers/questions/204058/how-to-execute-this-command-in-cmd-prompt-using-c
            var p = new Process
            {
                StartInfo =
                {
                    Arguments = "/C dir",
                    FileName = "cmd.exe",
                }
            };
            p.Start();
        }
    }
}