static class EnumTst
{

    enum MyColorEnum
    {
        Red,
        Greem,
        Blue
    }

    public static void Test()
    {
        MyColorEnum mce = MyColorEnum.Greem;
        PassParam(mce);

        Console.WriteLine("foreach");
        foreach (var c in Enum.GetValues(typeof(MyColorEnum)))
        {
            Console.WriteLine(c);
        };

    }

    static void PassParam(MyColorEnum mce)
    {
        Console.WriteLine(mce);

    }
}