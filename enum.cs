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
        }
        ;

        mce = (MyColorEnum)2;
        int n = Array.IndexOf(Enum.GetValues(typeof(MyColorEnum)), mce);

        MyColorEnum color = MyColorEnum.Greem;
        // Find the position of the enum value
        int position = Array.IndexOf(Enum.GetValues(typeof(MyColorEnum)), color);
        Console.WriteLine($"The position of {color} is {position}");        

    }

    static void PassParam(MyColorEnum mce)
    {
        Console.WriteLine(mce);
    }
}