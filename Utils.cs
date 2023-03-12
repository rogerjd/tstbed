using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Utils
{
    internal static void WriteTopic(string topic)
    {
        Console.WriteLine("\n{0} ****", topic);
    }

    internal static void WriteSubTopic(string subTtopic)
    {
        Console.WriteLine("  {0} **", subTtopic);
    }

    internal static void WriteDetailLine(string ln)
    {
        Console.WriteLine("    {0}", ln);
    }

    internal static string GetCmdArg(string[] args, int ArgNum)
    {
        if (MyMath.InRange(ArgNum, 0, args.Length - 1)) //if (args.Length > ArgNum && ArgNum > -1)
        {
            return args[ArgNum];
        }
        else
        {
            return "";
        }
    }
}

static class MyMath
{
    public static bool InRange(int val, int min, int max)
    {
        if (max < min)
            throw new ArgumentException("InRange(): max < min");
        return val >= min && val <= max;
    }
}
